using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using practicalWork3.UsersClasses;

namespace practicalWork3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "viktor20089@gmail.com";
            textBoxName.Text = "Дмитрий Александрович";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
            string.IsNullOrWhiteSpace(textBoxName.Text) ||
            string.IsNullOrWhiteSpace(textSubject.Text) ||
            string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }


            string smtp = "smtp.mail.ru";
            StringPair fromInfo = new StringPair("gw45yhg34t@mail.ru", "Гращенко Дмитрий Александрович");
            string password = "ZAZ1qU6zSxkaCgv22AzZ";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textSubject.Text;
            string body = $"{DateTime.Now} \n" +
                          $"{Dns.GetHostName()} \n" +
                          $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                          $"{textBoxBody.Text}";

            InfoEmailSending info =
                new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);

            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();

            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }
        }
    }
}
