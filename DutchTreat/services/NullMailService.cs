using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DutchTreat.services
{
    public interface IMailService
    {
        void SendMessage(string to, string subject, string body);
    }

    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> _logger;
        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string to, string subject, string body)
        {
            // log the message

            _logger.LogInformation($"To :{to} subject :{subject} Body : {body}");
        }
    }
}
