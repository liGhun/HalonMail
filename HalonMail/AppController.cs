using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalonMail.UserInterface;
using HalonMail.Core;
using HalonMail.Core.Model;

namespace HalonMail
{
    public class AppController
    {
        public static AppController Current;
        public MainWindow mainWindow { get; set; }
        public Storage CoreDataStorage { get; set; }

        public static void Start()
        {
            if (Current == null)
            {
                Current = new AppController();
            }
        }

        private AppController()
        {
            // we initiate a storage place from the HalonMail.Core namespace here
            CoreDataStorage = new Storage();

            mainWindow = new MainWindow();

            mainWindow.listBoxAccounts.ItemsSource = CoreDataStorage.Accounts;
            mainWindow.Show();
        }
    }
}
