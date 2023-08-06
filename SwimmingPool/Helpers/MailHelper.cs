using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool.Helpers
{
    public class MailHelper
    {
        private static string host = "smtp.gmail.com";
        private static int port = 587;
        private static bool enableSSL = true;
        private static string email = "duykhang.trinh1308@gmail.com";
        private static string password = "roqalmldqrjdmsqm";

        public static bool Send(string to, string subject, string content)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = email,
                        Password = password,
                    }
                };
                var mailMessage = new MailMessage(email, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.Message);
                return false;
            }
        }

        public static bool Send(string to, string subject, string content, bool isHTML)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = email,
                        Password = password,
                    }
                };
                var mailMessage = new MailMessage(email, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = isHTML;
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.Message);
                return false;
            }
        }

        public static bool Send(string to, string subject, string content, bool isHTML, string attachment)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = email,
                        Password = password,
                    }
                };
                var mailMessage = new MailMessage(email, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = isHTML;
                var attach = new Attachment(attachment);
                mailMessage.Attachments.Add(attach);
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.Message);
                return false;
            }
        }

        public static bool Send(string to, string subject, string content, bool isHTML, string[] attachments)
        {
            try
            {
                var smtpClient = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = enableSSL,
                    Credentials = new NetworkCredential
                    {
                        UserName = email,
                        Password = password,
                    }
                };
                var mailMessage = new MailMessage(email, to);
                mailMessage.Subject = subject;
                mailMessage.Body = content;
                mailMessage.IsBodyHtml = isHTML;
                foreach (var attachment in attachments)
                {
                    var attach = new Attachment(attachment);
                    mailMessage.Attachments.Add(attach);

                }
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception e1)
            {
                Debug.WriteLine(e1.Message);
                return false;
            }
        }
    }
}
