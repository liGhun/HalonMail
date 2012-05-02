using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace HalonMail.Core.Model
{
    public class Account_IMAP : IAccount
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public bool AcceptSelfSignedCertificateWithoutCheck { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public ObservableCollection<Folder_IMAP> Folders { get; set; }

        ActiveUp.Net.Mail.Imap4Client imapClient;

        public Account_IMAP()
        {
            imapClient = new ActiveUp.Net.Mail.Imap4Client();
            Folders = new ObservableCollection<Folder_IMAP>();

            Name = "Default";
            Server = "localhost";
            Port = 143;

            // let's add some example folders :)
        }

        public override string ToString()
        {
            return Name;
        }

        public bool CheckLogin()
        {
            return true;
        }

        public bool CheckLogin(string username, string password)
        {
            Username = username;
            Password = password;
            return CheckLogin();
        }

        public void ReceiveMails()
        {

        }
    }
}
