using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay4PowerCustomerCareApp.Core.Enums
{
    public class Enum
    {
        public enum TranStatus
        {
            Failed,
            Success,
            Error
        }

        public enum TranType
        {
           Card,
           Wallet,
           Remitta,
           Cash
        }

        public enum Roles
        {
            Admin,
            AppUser,
            CustomerCare
        }
    }
}
