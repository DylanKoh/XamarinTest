using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTest
{
    //Initial commit
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            var database = await App.Database.GetUserAsync();
            if (database.Where(x => x.username == entryUsername.Text && x.password == entryPassword.Text).Select(x => x).FirstOrDefault() != null)
            {
                await DisplayAlert("Login", $"Welcome {entryUsername.Text}!", "Ok");
            }
            else
            {
                await DisplayAlert("Login", $"Login failed!", "Ok");
            }
        }
    }
}