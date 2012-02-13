using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HalonMail.Core.Model
{
    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EMailAdress { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} <{2}>", Firstname, Lastname, EMailAdress);
        }

        public Person()
        {
            Firstname = "Vorname";
            Lastname = "Nachname";
            EMailAdress = "vorname.nachname@gmail.com";
        }
    }

}
