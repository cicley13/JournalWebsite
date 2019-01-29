using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace JournalWebsite
{
    class Access
    {
        public static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=JournalWebsite;Integrated Security=True";
        SqlConnection JournalWebsite = new SqlConnection(connection);

        public bool login(string user, string password)
        {
            string query = $"SELECT [User Name], [Password] FROM [User] WHERE [User Name] = '{user}' AND [Password] = '{password}'";

            SqlDataAdapter data = new SqlDataAdapter(query, JournalWebsite);

            DataTable table = new DataTable();

            data.Fill(table);

            if (table.Rows.Count == 1)
            {
                return true;
            }

            else
            {
                return false;
            }

        }

        public void register(string user, string password)
        {
            string query = $"SELECT [User Name] FROM [User] WHERE [User Name] = '{user}'";

            SqlDataAdapter data = new SqlDataAdapter(query, JournalWebsite);

            DataTable table = new DataTable();

            data.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Taken");
            }

            else
            {
                string query2 = "INSERT INTO [User] ([User Name], [Password]) VALUES (@user, @pass)";

                JournalWebsite.Open();

                SqlCommand cmd = new SqlCommand(query2, JournalWebsite);


                cmd.Parameters.AddWithValue("@user", );

                cmd.ExecuteNonQuery();

                JournalWebsite.Close();

                MessageBox.Show("Updated");

            }
        }
    }
}
