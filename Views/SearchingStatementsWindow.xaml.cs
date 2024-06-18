using StatementApp.Core;
using StatementApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace StatementApp.Views
{
    /// <summary>
    /// Логика взаимодействия для SearchingStatementsWindow.xaml
    /// </summary>
    public partial class SearchingStatementsWindow : Window
    {
        public SearchingStatementsWindow()
        {
            InitializeComponent();
        }

        public SearchingStatementsWindow(User user)
        {
            InitializeComponent();
            List<Statement> statements = GetStatementsList(user);
            MessageBox.Show($"{statements.Count}");
            lvStatements.ItemsSource = statements;
        }

        private List<Statement> GetStatementsList(User user)
        {
            var statementsList = new List<Statement>();
            switch (user.Role.Title)
            {
                case "Client":
                    foreach(UserStatements us in user.UserStatements)
                    {
                        MessageBox.Show($"{us.Statement.ID}");
                        statementsList.Add(us.Statement);
                    }
                    break;

                case "Master":
                    statementsList = DatabaseContext.Database.Statement.ToList();
                    break;

                case "Manager":
                    statementsList = DatabaseContext.Database.Statement.ToList();
                    break;

                case "Operator":
                    statementsList = DatabaseContext.Database.Statement.ToList();
                    break;

                default: break;
            }

            return statementsList;
        }
    }
}