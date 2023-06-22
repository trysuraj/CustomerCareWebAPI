using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay4PowerCustomerCareApp.Core.Models
{
    public class AccountDpt : BaseEntity
    {
        public string AccountantName { get; set; }
        public string Role { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }

    }
}
