using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            //userId'yi bul email'ini al vs vs...

            var apiKey = _configuration.GetSection("Api")["SendGridKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("canxmcclynd1@gmail.com", "Can Canbolat");
            var subject = "Kayıt mesajı";

            var to = new EmailAddress("randomhesaplar@gmail.com", "Random Hesap");
            var plainTextContent = $"Merhaba Random Hesaplar {userId}. {message}";
            var htmlContent = "<strong>İyi günler dileriz</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
