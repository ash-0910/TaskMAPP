using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TaskMAPP
{
    public partial class MainPage : ContentPage
    {
        Helper helper = new Helper();
        public MainPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            try
            {
                var alltasks = await helper.GetAllTask();
                tasklistview.ItemsSource = alltasks;
            }
            catch(Exception ex)
            {
               await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
