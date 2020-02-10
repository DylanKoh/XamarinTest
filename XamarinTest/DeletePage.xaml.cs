using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePage : ContentPage
    {
        public DeletePage()
        {
            InitializeComponent();
        }
        public async void btnDelete_Clicked(object sender, EventArgs e)
        {
            var database = await App.Database.GetUserAsync();
            var getUser = database.Where(x => x.username == entryUsername.Text && x.password == entryPassword.Text).Select(x => x).FirstOrDefault();
            if (getUser != null)
            {
                var dl = await DisplayAlert("Delete", "Are you sure you want to delete?", "Yes", "Cancel");
                if (dl == true)
                {
                    await App.Database.DeleteUserAsync(getUser);
                    await DisplayAlert("Delete", $"Deleted User: {getUser.username}", "Ok");
                    await Navigation.PushAsync(new MainPage());
                }
            }
        }
    }
}