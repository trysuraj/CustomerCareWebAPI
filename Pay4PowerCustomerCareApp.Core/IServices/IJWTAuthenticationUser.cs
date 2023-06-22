using Pay4PowerCustomerCareApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay4PowerCustomerCareApp.Core.IServices
{
    public interface IJWTAuthenticationUser
    {
        RefreshToken GenerateRefreshToken();
        string CreateToken(User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        void SetRefreshToken(RefreshToken newRefreshToken);
    }
}
