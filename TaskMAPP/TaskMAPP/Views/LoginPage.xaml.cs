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
    public partial class LoginPage : ContentPage
    {
        Helper helper = new Helper();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void forgotpass_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new ForgotPassword()));
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            string email = EntryUserEmail.Text.ToString();
            string password = EntryPassword.Text.ToString();
            try
            {
                var response = await helper.FirebaseLogin(email,password);

                if (response == false)
                {
                    await DisplayAlert("Error", "The User was not found. Please contact your administrator", "OK");
                }
                else
                {
                    await Navigation.PushAsync(new NavigationPage(new TabbedPage()));
                    Navigation.RemovePage(this);

                }
            }
            catch(Exception ex)
            {
               await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

  
}