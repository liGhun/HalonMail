using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalonMail.Core.Model
{
    public class Account_SMTP : IAccount
    {
        public string Name
        {
            get;
            set;
        }

        public string Server
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public bool UseSSL
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public Account_SMTP()
        {
            Name = "";
            Server = "";
            Port = 465;
            UseSSL = true;
            Username = "";
            Password = "";
        }

        public void SendEmail(string subject, string text, string receiver, string CC, string BCC)
        {

        }


        public bool AcceptSelfSignedCertificateWithoutCheck
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool CheckLogin()
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
