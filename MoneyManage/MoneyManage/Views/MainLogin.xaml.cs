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
    public partial class MainLogin : ContentPage
    {
        public MainLogin()
        {
            InitializeComponent();
            
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }
    }
}