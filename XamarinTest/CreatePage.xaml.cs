using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest.Model;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
        }

        private async void btnCreate_Clicked(object sender, EventArgs e)
        {
            User user = new User();
            user.username = entryUsername.Text;
            user.password = entryPassword.Text;
            var database = await App.Database.GetUserAsync();
            if (database.Where(x => x.username == entryUsername.Text).Select(x => x).FirstOrDefault() == null)
            {
                await App.Database.AddUserAsync(user);
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Create", "User ID already exist in database!", "Ok");
            }
        }
    }
}