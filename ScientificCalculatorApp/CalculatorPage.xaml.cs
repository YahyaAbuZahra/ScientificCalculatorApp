using Microsoft.Maui.Controls;

namespace ScientificCalculatorApp.Views
{
    public partial class CalculatorPage : ContentPage
    {
        private double firstNumber;
        private string operation;
        private bool isNewEntry = true;

        public CalculatorPage()
        {
            InitializeComponent();
        }

        private void numarator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isNewEntry)
            {
                ekran.Text = button.Text; // Start a new entry
                isNewEntry = false; // Mark that we are no longer starting a new entry
            }
            else
            {
                ekran.Text += button.Text; // Append the number to the current text
            }
        }

        private void tamamensil(object sender, EventArgs e)
        {
            ekran.Text = "0"; // Reset the display
            isNewEntry = true; // Allow new entry
        }

        private void onBackspaceClicked(object sender, EventArgs e)
        {
            if (ekran.Text.Length > 1)
                ekran.Text = ekran.Text.Substring(0, ekran.Text.Length - 1); // Remove last character
            else
                ekran.Text = "0"; // If text length is one, reset to 0
        }

        private void onDecimalClicked(object sender, EventArgs e)
        {
            if (!ekran.Text.Contains("."))
                ekran.Text += "."; // Add decimal point if not present
        }

        private void onSquareClicked(object sender, EventArgs e)
        {
            if (double.TryParse(ekran.Text, out double number))
                ekran.Text = (number * number).ToString(); // Square the number
        }

        private void onSqrtClicked(object sender, EventArgs e)
        {
            if (double.TryParse(ekran.Text, out double number))
                ekran.Text = Math.Sqrt(number).ToString(); // Square root
        }

        private void toplama(object sender, EventArgs e)
        {
            firstNumber = double.Parse(ekran.Text);
            operation = "+"; // Set operation
            isNewEntry = true; // Allow new entry
        }

        private void cikarma(object sender, EventArgs e)
        {
            firstNumber = double.Parse(ekran.Text);
            operation = "-"; // Set operation
            isNewEntry = true; // Allow new entry
        }

        private void carpma(object sender, EventArgs e)
        {
            firstNumber = double.Parse(ekran.Text);
            operation = "*"; // Set operation
            isNewEntry = true; // Allow new entry
        }

        private void bolme(object sender, EventArgs e)
        {
            firstNumber = double.Parse(ekran.Text);
            operation = "/"; // Set operation
            isNewEntry = true; // Allow new entry
        }

        private void sonuc(object sender, EventArgs e)
        {
            if (double.TryParse(ekran.Text, out double secondNumber))
            {
                double result = 0;
                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber; // Prevent division by zero
                        break;
                }
                ekran.Text = result.ToString(); // Display result
                isNewEntry = true; // Allow new entry after calculation
            }
        }

        private async void OnBackToLoginClicked(object sender, EventArgs e)
        {
            // Navigate back to the login page
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
