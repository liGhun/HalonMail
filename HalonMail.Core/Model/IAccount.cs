using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalonMail.Core.Model
{
    interface IAccount
    {
        string Name { get; set; }
        string Server { get; set; }
        int Port { get; set; }
        bool UseSSL { get; set; }
        bool AcceptSelfSignedCertificateWithoutCheck { get; set; }

        string Username { get; set; }
        string Password { get; set; }

        bool CheckLogin();
        bool CheckLogin(string username, string password);
    }
}
