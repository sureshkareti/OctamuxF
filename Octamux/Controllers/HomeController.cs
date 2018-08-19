using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Octamux.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Octamux()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult SendEmailContactForm(string name, string email, string phoneNum, string message)
        {
            bool isSuccess = true;
            try
            {
                MailMessage msgs = new MailMessage();
                msgs.To.Add(new MailAddress("octamux.info@gmail.com"));
                MailAddress address = new MailAddress("abc@domain.com");
                msgs.From = new MailAddress("octamux.info@gmail.com");
                msgs.Subject = "Hello!!! "+ name + " Contacted you.";
                msgs.Sender = new MailAddress("octamux.info@gmail.com");

                var body = new StringBuilder();
                body.AppendLine("Dear Octamux,");
                body.AppendLine();
                body.AppendLine("the user has contacted you and details are below.");
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Name : " + name + "");
                body.AppendLine();
                body.AppendLine("Email : " + email + "");
                body.AppendLine();
                body.AppendLine("Phone Number : " + phoneNum + "");
                body.AppendLine();
                body.AppendLine("Message : " + message + "");
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Thanks,");
                body.AppendLine(name);

                msgs.Body = body.ToString();
                msgs.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = "relay-hosting.secureserver.net";
                //client.Host = "smtp.gmail.com";
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("octamux.info@gmail.com", "octamux2018");
                //Send the msgs  
                client.Send(msgs);
            }
            catch (Exception ex)
            {
                isSuccess = false;
              
               // Models.Library.WriteLog("Error occured while sending an email from contact form ", ex);
            }
            ViewBag.send = isSuccess;
            //return isSuccess;
            return View("Octamux");
        }
    }
}