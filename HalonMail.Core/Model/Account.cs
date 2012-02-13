using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace HalonMail.Core.Model
{
    public class Account
    {
        public enum AccountTypes
        {
            IMAP,
            POP3
        }

        public string Name { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        public bool UseSSL { get; set; }
        public AccountTypes AccountType { get; set; }

        public string Username { get; set; }
        public string Passwort { get; set; }

        public ObservableCollection<Folder> Folders { get; set; }

        public Account()
        {
            Folders = new ObservableCollection<Folder>();

            Name = "Default";
            Server = "localhost";
            Port = 143;
            AccountType = AccountTypes.IMAP;

            // let's add some example folders :)
        }

        public override string ToString()
        {
            return Name;
        }

        public void ReceiveMails()
        {

        }
    }
}
