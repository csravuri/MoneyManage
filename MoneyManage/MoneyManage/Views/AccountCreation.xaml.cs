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
    public partial class AccountCreation : ContentPage
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        
        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["PIN"] = this.txtEnterPin.Text;

            await Navigation.PushAsync(new Home());
        }

        
    }
}