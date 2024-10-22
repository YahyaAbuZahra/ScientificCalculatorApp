using Microsoft.Maui.Controls;

namespace ScientificCalculatorApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Validate username entry
            if (!string.IsNullOrWhiteSpace(usernameEntry.Text))
            {
                // Navigate to CalculatorPage
                Application.Current.MainPage = new NavigationPage(new CalculatorPage());
            }
            else
            {
                await DisplayAlert("Error", "Please enter your name", "OK");
            }
        }
    }
}
