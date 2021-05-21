using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;   
using System.Net.Mail;
using System.Threading.Tasks;

namespace rpc_laba3
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            SendEmail(request.Name);
            return Task.FromResult(new HelloReply
            {   
                Message = "����������"
            });
        }

        static void SendEmail(string currency)
        {
            MailAddress from = new MailAddress("bookstore@internet.ru", "������� WILDBOOKI");
            MailAddress to = new MailAddress("aleksandr.kz2000@mail.ru"); //tim.urfu@mail.ru
            MailMessage m = new MailMessage(from, to);
            m.Subject = "������������ �� ��������, ��� ���� �� ��� ��������� ������ ���� �� ��� �������, ������� ��� ������� � ����";
            m.Body = @$"<h3>������� ����� ����� � crb.ru</h3>
            <p>{currency}</p>
            <p>��������� ������� ������������ �����, � �� ����� �� ���� ��������</p>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("bookstore@internet.ru", "ghj100ghj100ghj");
            smtp.Send(m);
        }

    }
}
