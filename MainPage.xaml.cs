using System.Text.RegularExpressions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace URI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string username;
        private string password;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void setCredentials(string user, string pass)
        {
            this.username = user;
            this.password = pass;
        }

        private string getUser() { return username; }
        private string getPass() { return password; }
        private string Display()
        {
            return getUser() + " with password " + getPass() + " has been successfully registered.";
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            Match numericMatch = Regex.Match(pass, @".*[0-9]+.*[0-9]+.*");

            setCredentials(user, pass);
            if(txtPassword.Text == "")
            {
                lblError.Text = "Password cannot be empty";
            }
            else if(txtUsername.Text == "")
            {
                lblError.Text = "Username cannot be blank";
            }
            else if(txtPassword.Text.Length <= 8 && !numericMatch.Success)
            {
                lblError.Text = "Invalid password";
            }
            else
            {
                Frame.Navigate(typeof(Index));
            }
        }
    }
}
