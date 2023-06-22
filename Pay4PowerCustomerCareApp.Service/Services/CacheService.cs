using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Pay4PowerCustomerCareApp.Core.IServices;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay4PowerCustomerCareApp.Service.Services
{
    public class CacheService : ICacheService
    {
        private static ConcurrentDictionary<string, bool> Cachekeys = new();
        private readonly IDistributedCache _distributedCashe;
        public CacheService(IDistributedCache distributedCashe)
        {
            _distributedCashe = distributedCashe;
        }

        public async Task<T> GetAsyc<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default) where T : class
        {
            T? cacheValue = await GetAsyc<T>(key, cancellationToken);
            if (cacheValue is not null)
            {
                return cacheValue;
            }

            cacheValue = await factory();
            await SetAsync(key, cacheValue, cancellationToken);
            return cacheValue;
        }

        public async Task<T?> GetAsyc<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            string? cashedValue = await _distributedCashe.GetStringAsync(key, cancellationToken);
            if (cashedValue is null)
            {
                return null;
            }
            T? value = JsonConvert.DeserializeObject<T>(cashedValue);
            return value;
        }

        public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCashe.RemoveAsync(key, cancellationToken);

            Cachekeys.TryRemove(key, out bool _);
        }

        public async Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
        {
            //foreach (string key in Cachekeys.Keys)
            //{
            //    if (key.StartsWith(prefixKey))
            //    {
            //        await RemoveAsync(key, cancellationToken);
            //    }
            //}

            IEnumerable<Task> tasks = Cachekeys.Keys.Where(k => k.StartsWith(prefixKey))
                .Select(k => RemoveAsync(k, cancellationToken));

            await Task.WhenAll(tasks);
        }

        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            string casheValue = JsonConvert.SerializeObject(value);

            await _distributedCashe.SetStringAsync(key, casheValue, cancellationToken);

            Cachekeys.TryAdd(key, false);
        }
    }
}
