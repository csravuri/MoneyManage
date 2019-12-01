using MoneyManage.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Init();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Init();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Init();
        }

        private void Init()
        {
            if (Application.Current.Properties.ContainsKey("PIN") && Application.Current.Properties["PIN"] != null)
            {
                MainPage = new MainLogin();
            }
            else
            {
                MainPage = new AccountCreation();
            }
        }


    }
}
