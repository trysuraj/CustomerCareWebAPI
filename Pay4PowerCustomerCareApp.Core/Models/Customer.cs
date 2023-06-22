using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pay4PowerCustomerCareApp.Core.Enums.Enum;

namespace Pay4PowerCustomerCareApp.Core.Models
{
    public class Customer:BaseEntity
    {
       
        public string CustomerName { get; set; }
        public string AgentName { get; set; }
        public string CustomerEmail { get; set; }
        public string Description { get; set; }
        public string TransactionRefNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string MeterNumber { get; set; }
        public string DISCO { get; set; }
        public double Amount { get; set; }
        public string MeterType { get; set; }
        public TranType PaymentMode { get; set; }
        public bool IsApproved { get; set; }

    }
}
