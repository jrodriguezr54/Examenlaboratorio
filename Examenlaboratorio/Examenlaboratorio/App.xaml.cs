using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Examenlaboratorio.controllers;
using Examenlaboratorio.models;
using System.IO;

namespace Examenlaboratorio
{
    public partial class App : Application
    {

        static database data;
        public static database Database
        {
            get 
            { 
                var dbpath = string.Empty;
                var namedb = string.Empty;
                var fullpath = string.Empty;

                dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                namedb = "DBcontactos.db3";
                fullpath = Path.Combine(dbpath, namedb);

                if (data == null)
                {
                    data = new database(fullpath);
                } 
            return data;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new views.Pageinicial());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
