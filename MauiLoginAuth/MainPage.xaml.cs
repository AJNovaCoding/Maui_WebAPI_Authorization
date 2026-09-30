using System.Threading.Tasks;

namespace MauiLoginAuth
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object? sender, EventArgs e)
        {
            //Get the username and password from the entry fields
            string username = txtUserId.Text;
            string password = txtPassword.Text;

            //Create an instance of USerAuthentication
            var userAuth = new DataAccess.UserAuthentication();

            //Authenticate the user
            bool isAuthenticated = userAuth.AuthenticateUser(username, password);

            //Display authentication
            if (isAuthenticated)
            {
                await DisplayAlert("Login Successful", "You have been successfully authenticated.", "OK");

                await Navigation.PushAsync(new DataEntry());
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password.", "OK");
            }
        }

        private void OnCancelClicked(object? sender, EventArgs e)
        {
            //Clear the entry fields
            txtUserId.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
    }
}
