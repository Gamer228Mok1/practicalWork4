using practicalWork3.UsersClasses;
using practicalWork3.UsersСlasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicalWork3.Userclasses
{
    internal class InfoGMail : InfoEmail
    {
        public InfoGMail(StringPair emailAdressTo, string subject, string body)
        : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.gmail.com";
            EmailAdressFrom = new StringPair("is25graschenkoda@artcollege.ru", "Гращенко Дмитрий Александрович");
            EmailPassword = "hrxe lxvz ovre pchn";
            Port = 587;
        }

    }
}