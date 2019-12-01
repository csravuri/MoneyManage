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
            try
            {
                this.btnLogin.Text = Application.Current.Properties["PIN"].ToString();
            }
            catch(Exception e)
            {
                this.btnLogin.Text = e.Message;
            }
        }
    }
}