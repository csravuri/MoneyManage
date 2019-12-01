using MoneyManage.Data;
using MoneyManage.Models;
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
    public partial class PersonCreation : ContentPage
    {
        public PersonCreation()
        {
            InitializeComponent();
        }


        private bool FieldsValid()
        {
            if (string.IsNullOrWhiteSpace(this.personName.Text))
            {
                DisplayAlert("Alert!", this.personName.Placeholder + " is required", "ok");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (FieldsValid())
            {
                MoneyManageDB database = MoneyManageDB.Database;
                Person person = new Person()
                {
                    personName = this.personName.Text.Trim(),
                    mobileNo = this.mobileNo.Text?.Trim(),
                    email = this.email.Text?.Trim(),
                    address = this.adress.Text?.Trim(),
                    createdDate = DateTime.Now
                };

                int a = database.SaveAsync(person).Result;

                int b = database.GetPersonsAsync().Result.Count();

                DisplayAlert("Success! count "+b.ToString(), a.ToString(), "ok");
                ClearFields();

               
            }

            

        }

        private void ClearFields()
        {
            this.personName.Text = string.Empty;
            this.mobileNo.Text = string.Empty;
            this.email.Text = string.Empty;
            this.adress.Text = string.Empty;


        }
    }
}