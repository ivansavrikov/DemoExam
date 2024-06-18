using StatementApp.Core;
using StatementApp.Model;
using StatementApp.Views;
using System.Linq;
using System.Windows;

namespace StatementApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = DatabaseContext.Database.User.Where(u => u.Login == tbLogin.Text && u.Password == tbPassword.Text).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show($"Welcome {user.FirstName} you are {user.Role.Title}");
                new SearchingStatementsWindow(user).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show($"Error Logining");
            }
        }
    }
}
