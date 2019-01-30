using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JournalLibrary
{
    public class Profile
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=JournalWebsite;Integrated Security=True";
        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public static bool editProfile(string username, string password, string newusername, string newpassword)
        {
            string SELECT = $"SELECT [LogInID], [UserName], [Password] FROM [User info] WHERE [UserName] = '{username}' AND [Password] = '{password}'";

            SqlDataAdapter edit = new SqlDataAdapter(SELECT, JournalWebsite);

            DataTable table = new DataTable();

            edit.Fill(table);

            if (table.Rows.Count == 1)
            {
                return false;
            }
            else if (newpassword == "" || newpassword.Length < 1)
            {
                return false;
            }
            else
            {
                string SlogID = table.Rows[0]["LogInId"].ToString();
                string UPDATE = $"UPDATE [User info] SET [UserName] = '{newusername}', [Password] = '{newpassword}' WHERE [LogInID] ={SlogID}";

                SqlCommand command = new SqlCommand(UPDATE, JournalWebsite);
                return true;
            }
        }
    }
}
