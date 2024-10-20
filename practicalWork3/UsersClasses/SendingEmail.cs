using System;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace practicalWork3.UsersСlasses
{
    public class SendingEmail
    {
        private InfoEmail InfoEmail { get; set; }

        public SendingEmail(InfoEmail infoEmail)
        {
            InfoEmail = infoEmail
            ?? throw new ArgumentNullException(nameof(infoEmail));
        }

        public void Send()
        {
            try
            {
                SmtpClient mySmtpClient =
                    new SmtpClient(InfoEmail.SmtpClientAdress);

                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.EnableSsl = true;

                if (InfoEmail.Port != -1)
                    mySmtpClient.Port = InfoEmail.Port;

                NetworkCredential basicAuthenticationInfo = new
                   NetworkCredential(
                   InfoEmail.EmailAdressFrom.EmailAdress,
                   InfoEmail.EmailPassword);

                mySmtpClient.Credentials = basicAuthenticationInfo;

                MailAddress from = new MailAddress(
                InfoEmail.EmailAdressFrom.EmailAdress,
                InfoEmail.EmailAdressFrom.Name);
                MailAddress to = new MailAddress(
                InfoEmail.EmailAdressTo.EmailAdress,
                InfoEmail.EmailAdressTo.Name);

                MailMessage myMail = new MailMessage(from, to);

                MailAddress replyTo =
                    new MailAddress(InfoEmail.EmailAdressFrom.EmailAdress);
                myMail.ReplyToList.Add(replyTo);

                Encoding encoding = Encoding.UTF8;
                myMail.Subject = InfoEmail.Subject;
                myMail.SubjectEncoding = encoding;

                myMail.Body = InfoEmail.Body;
                myMail.BodyEncoding = encoding;

                // Отправляем письмо
                mySmtpClient.Send(myMail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
