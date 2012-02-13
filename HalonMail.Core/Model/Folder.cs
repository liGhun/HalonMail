using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace HalonMail.Core.Model
{
    public class Folder
    {
        public string Name { get; set; }
        public ObservableCollection<Folder> SubFolders { get; set; }
        public ObservableCollection<EMail> EMails { get; set; }

        public int NumberOfEmails
        {
            get
            {
                return EMails.Count();
            }
        }

        public int NumberOfUnreadEmails
        {
            get
            {
                return EMails.Where(e => !e.IsRead).Count();
            }
        }

        public Folder()
        {
            SubFolders = new ObservableCollection<Folder>();
            EMails = new ObservableCollection<EMail>();
            Name = "Foldername";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
