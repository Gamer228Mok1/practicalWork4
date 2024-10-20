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
using practicalWork3.UsersСlasses;
using practicalWork3.Userclasses;

namespace practicalWork3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "";
            textBoxName.Text = "Дмитрий Александрович";
            comboBoxService.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (IsNullOrWhiteSpaceTextBox())
                return;

            try
            {
                SendingEmail sendingEmail = new SendingEmail(
                    SetInfoEmail(
                        comboBoxService.SelectedItem.ToString() == "GMail" ?
                        EmailsTypes.GMail :
                        EmailsTypes.MailRu));

                sendingEmail.Send();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("Письмо отправлено!");
            TextBoxIsCleaning();
        }
        private bool IsNullOrWhiteSpaceTextBox()
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textSubject.Text) ||
                string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return true;
            }

            return false;
        }
        private void TextBoxIsCleaning()
        {
            DialogResult result = MessageBox.Show("Очистить поля ввода?",
                                                  "Сообщение",
                                                  MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                foreach (TextBox textBox in Controls.OfType<TextBox>())
                {
                    textBox.Text = "";
                }
            }
        }

        private InfoEmail SetInfoEmail(EmailsTypes type)
        {
            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textSubject.Text;
            string body = $"{DateTime.Now} \n" +
                          $"{Dns.GetHostName()} \n" +
                          $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
                          $"{textBoxBody.Text}";
            if (type == EmailsTypes.GMail)
                return new InfoGMail(toInfo, subject, body);
            else
                return new InfoEmailRu(toInfo, subject, body);


        }
    }
}
