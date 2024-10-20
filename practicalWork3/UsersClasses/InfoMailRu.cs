using practicalWork3.UsersClasses;
using practicalWork3.UsersСlasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicalWork3.Userclasses
{
    internal class InfoEmailRu : InfoEmail
    {
        public InfoEmailRu(StringPair emailAdressTo, string subject, string body)
        : base(emailAdressTo, subject, body)
        {
            SmtpClientAdress = "smtp.mail.ru";
            EmailAdressFrom = new StringPair("gw45yhg34t@mail.ru", "Гращенко Дмитрий Александрович");
            EmailPassword = "ZAZ1qU6zSxkaCgv22AzZ";
            Port = -1;
        }

    }
}