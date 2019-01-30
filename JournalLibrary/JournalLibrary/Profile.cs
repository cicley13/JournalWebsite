using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JournalLibrary
{
    class Profile
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=JournalWebsite;Integrated Security=True";
        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public static bool editProfile(string username, string password)
        {
            string SELECT = $"SELECT [LogInID], [User Name], [Password] FROM [User] WHERE [User Name] = '{username}' AND [Password] = '{password}'";

            SqlDataAdapter edit = new SqlDataAdapter(SELECT, JournalWebsite);

            return true;
        }
    }
}
