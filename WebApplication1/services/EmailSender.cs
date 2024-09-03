using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("9206efc5041a3e", "ee7bfa4c82a651"),
                EnableSsl = true
            };
            client.SendMailAsync("support@hguide.com", email, subject, htmlMessage);
            System.Console.WriteLine("Sent");
            return Task.CompletedTask;
        }

    }
}
