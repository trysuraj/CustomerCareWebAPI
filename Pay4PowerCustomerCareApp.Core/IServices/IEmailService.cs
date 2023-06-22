using Pay4PowerCustomerCareApp.Core.Models;
using Pay4PowerCustomerCareApp.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay4PowerCustomerCareApp.Core.IServices
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
