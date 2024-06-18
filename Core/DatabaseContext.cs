using StatementApp.Model;

namespace StatementApp.Core
{
    public static class DatabaseContext
    {
        public static DBEntities Database { get; private set; }

        static DatabaseContext()
        {
            Database = new DBEntities();
        }

        public static User currentUser = null;
    }
}