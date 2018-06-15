using spinecases2.FTSEmailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace spinecases2.Controllers
{
    public class HomeController : Controller
    {
     
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Login()
        {
           

            return View();
        }
        public ActionResult Team()
        {


            return View();
        }
        public JsonResult ContactUs(string firstname, string lastname, string email, string phone, string msg)
        {

            using (TbEmailServiceClient emailClient = new TbEmailServiceClient("BasicHttpsBinding_ITbEmailService"))
            {
                var result = emailClient.SendEmail(SendEmailMsgRequestDto.EmailType.None, new SendEmailMsgRequestDto
                {
                    Bcc = new[] { "andyf280@gmail.com" },
                    Body = $"<html><body>" +
                           $"<p><strong>Name:</strong> {firstname} {lastname}</p><br/>" +
                           $"<p><strong>Email:</strong> {email}</p><br/>" +
                           $"<p><strong>Phone:</strong> {phone}</p><br/>" +
                           $"<p><strong>Message:</strong> {msg}</p>" +
                           $"</body></html>",
                    Cc = new string[0],
                    FromAddress = "info@falcontechnologysolutions.com",
                    FromDisplayName = "SpinED",
                    IsBodyHtml = true,
                    MainHeader = $"This message was sent using the Contact Us form on spined.com by {email}",
                    Subject = $"Message recieved from SpinED.com",
                    To = new[] { "colby.oitment@medportal.ca"/*System.Configuration.ConfigurationManager.AppSettings["ContactUsEmail"]*/ },
                });
                return result.ErrorMessageDto == null ?
                    Json(new { status = "200", msg = $"{firstname}, your message has been sent!" }, JsonRequestBehavior.AllowGet)
                  : Json(new { status = "500", msg = "Whoops! Unable to send message." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}