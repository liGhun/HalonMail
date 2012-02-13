using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace HalonMail.Core.Model
{
    public class EMail
    {
        public Person Sender { get; set; }
        public ObservableCollection<Person> Receivers_To { get; set; }
        public string Receivers_To_String
        {
            get
            {
                return string.Join(";", Receivers_To);
            }
            set
            {
                // for now ignored :)
            }
        }
        public ObservableCollection<Person> Receivers_Cc { get; set; }
        public ObservableCollection<Person> Receivers_Bcc { get; set; }

        public List<string> Headers { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }

        public bool IsRead { get; set; }

        public override string ToString()
        {
            return Subject + " by " + Sender;
        }

        public EMail()
        {
            Sender = new Person();
            Receivers_To = new ObservableCollection<Person>();
            Receivers_Cc = new ObservableCollection<Person>();
            Receivers_Bcc = new ObservableCollection<Person>();
            Headers = new List<string>();

            IsRead = false;
        }
    }
}
