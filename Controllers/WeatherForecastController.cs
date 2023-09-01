using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using MimeKit;
using MailKit.Security;
namespace simplemail.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public string Get()
    {
         try
            {
                 Console.WriteLine("Sending using .Mailkit! press enter");
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("Cubehr App", "nssheheerali@gmail.com"));
            email.To.Add(new MailboxAddress("SHEHEER", "nssheheerali@gmail.com"));

            email.Subject = "Testing out email sending";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { 
                Text = "<b>Hello all the way from the land of C#</b>"
            };

            using (var smtpc = new MailKit.Net.Smtp.SmtpClient())
            {
                // smtpc.Connect("smtp.gmail.com", 465, SecureSocketOptions.StartTls);
                smtpc.Connect("smtp.gmail.com", 465, true);
                

                // Note: only needed if the SMTP server requires authentication
                smtpc.Authenticate("nssheheerali@gmail.com", "ngozruvgxmsxizpj");

                smtpc.Send(email);
                smtpc.Disconnect(true);
            }
            Console.WriteLine("sent from Mailkit!");
             return "succces";
            }
            catch (Exception ex)
            {
                Console.WriteLine("sent from Mailkit! Failed");
                return ex.Message;
            }
    }

   
}
