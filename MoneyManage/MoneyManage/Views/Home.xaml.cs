using MoneyManage.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyManage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
        }


        private async void AddPerson_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonCreation());
        }

        protected override bool OnBackButtonPressed()
        {            
            return true;
        }

        private async void BtnClear_Clicked(object sender, EventArgs e)
        {
            bool clear = await DisplayAlert("Warning", "Want to clear all?", "Yes", "No");
            if(clear)
            {
                MoneyManageDB database = MoneyManageDB.Database;
                bool result = database.DeleteAllAsync();
                if (result)
                {
                    DisplayAlert("Success", "", "ok");
                    App.Current.Quit();
                }
                else
                {
                    DisplayAlert("Failed", "Try after sometime", "ok");
                }
            }
        }
    }
}