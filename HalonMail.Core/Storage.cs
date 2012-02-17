using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using HalonMail.Core.Model;
using ActiveUp.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace HalonMail.Core
{
    public class Storage
    {
        public ObservableCollection<Account> Accounts { get; set; }

        public Storage()
        {
            Accounts = new ObservableCollection<Account>();

            // let's create testdata :)

            Person testReceiver = new Person(); // I am to lazy to copy paste more than one ;)
            testReceiver.Firstname = "The";
            testReceiver.Lastname = "Receiver";
            testReceiver.EMailAdress = "example@example.com";

            Account testAccount1 = new Account();
            testAccount1.Name = "IMAP4 test account by Sven";
            Folder folder1 = new Folder();
            folder1.Name = "Inbox";
            testAccount1.Folders.Add(folder1);
            EMail testEmail1 = new EMail();
            testEmail1.Sender.Firstname = "Sven";
            testEmail1.Sender.Lastname = "Walther";
            testEmail1.Receivers_To.Add(testReceiver);
            testEmail1.Subject = "This is a test subject";
            testEmail1.TextBody = "Hello World\r\nThis is just an example\r\nCheers\r\nSven";
            //folder1.EMails.Add(testEmail1);
            EMail testEmail12 = new EMail();
            testEmail12.Sender.Firstname = "Obi";
            testEmail12.Sender.Lastname = "Wan Kenobi";
            testEmail12.Receivers_To.Add(testReceiver);
            testEmail12.Subject = "May the force be with you";
            testEmail12.TextBody = "The force is strong in this app :)";
            folder1.EMails.Add(testEmail12);


            Account testAccount2 = new Account();
            testAccount2.Name = "Test account 2";
            Folder folder2 = new Folder();
            folder2.Name = "Inbox Account 2";
            EMail testEmail2 = new EMail();
            testEmail2.Sender.Firstname = "Chris";
            testEmail2.Sender.Lastname = "Peel";
            testEmail2.Receivers_To.Add(testReceiver);
            testEmail2.Subject = "This is another test subject";
            testEmail2.TextBody = "Hello World\r\nThis is just another example\r\nCheers\r\nChris";
            folder2.EMails.Add(testEmail2);
            testAccount2.Folders.Add(folder2);

            Accounts.Add(testAccount1);
            Accounts.Add(testAccount2);

            ActiveUp.Net.Mail.Imap4Client imapClient = new ActiveUp.Net.Mail.Imap4Client();

            
            
            ActiveUp.Net.Security.SslHandShake handshake = new ActiveUp.Net.Security.SslHandShake("localhost",System.Security.Authentication.SslProtocols.Default,ValidateRemoteCertificate);

            /* For testing I start with fixed login data - I just wanted to know if it works
             * 
             * you may want to exchange to your own environment here ;)) */

            imapClient.ConnectSsl("localhost", 13993,handshake);
            imapClient.Login("sven", "*****");
            imapClient.Command("capability");

            Mailbox inbox = imapClient.SelectMailbox("inbox");
            
            int[] ids = inbox.Search("UNSEEN");
            if (ids.Length > 0)
            {
                foreach (int id in ids)
                {
                    Message message = inbox.Fetch.MessageObject(id);
                    EMail email = new EMail();

                    email.Subject = message.Subject;
                    email.Sender.EMailAdress = message.Sender.Email;
                    email.Sender.Firstname = message.Sender.Name;
                    email.Sender.Firstname = message.Sender.Name;
                    email.TextBody = message.BodyText.TextStripped;
                    folder1.EMails.Add(email);

                }
                //Message msg_first = inbox.Fetch.MessageObject(ids[0]);
                
            }
            
        }

        private static bool ValidateRemoteCertificate(object sender, X509Certificate certificate,
    X509Chain chain,
    SslPolicyErrors policyErrors
)
        {
            return true;
            
        }

    }
}
