using StatementApp.Core;
using StatementApp.Model;
using System;
using System.Linq;
using System.Windows;

namespace StatementApp.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditStatement.xaml
    /// </summary>
    public partial class AddEditStatement : Window
    {
        public AddEditStatement()
        {
            InitializeComponent();
        }

        public void AddStatement(User user)
        {
            Statement statement = new Statement()
            {
                StartTime = DateTime.Now,
                Status = DatabaseContext.Database.Status.Where(s => s.Title == "Принята").FirstOrDefault(),
            };
            DatabaseContext.Database.Statement.Add(statement);

            UserStatements userStatements = new UserStatements()
            {
                User = user,
                Statement = statement,
            };

            DatabaseContext.Database.UserStatements.Add(userStatements);
            try
            {
                DatabaseContext.Database.SaveChanges();
                MessageBox.Show("Успешно");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                DatabaseContext.Database.Statement.Remove(statement);
                DatabaseContext.Database.UserStatements.Remove(userStatements);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddStatement(DatabaseContext.currentUser);
        }

        private void btnNavToStatementsList_Click(object sender, object e)
        {
            new SearchingStatementsWindow(DatabaseContext.currentUser).Show();
            this.Close();
        }
    }
}
