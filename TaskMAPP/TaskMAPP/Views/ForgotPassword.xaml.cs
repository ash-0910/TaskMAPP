using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskMAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        Helper helper = new Helper();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private async void ForgotPassbtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = EntryUserEmail.Text.ToString();

                var response = await helper.ResetPassword(email);

                if (response == true)
                {
                    await DisplayAlert("Success", "Please cheak your email to reset password", "OK");

                }
                else
                {
                    await DisplayAlert("Error", "No such Email found. please check your email or contact your administrator", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}