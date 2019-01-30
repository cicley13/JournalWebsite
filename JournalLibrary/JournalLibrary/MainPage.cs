using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JournalLibrary
{
    class MainPage
    {
        static string connection = "Data Source=DESKTOP-DJU5C3P\\SQLEXPRESS;Initial Catalog=Journal website;Integrated Security=True";
        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public void Stack()
        {
            string sa = $"SELECT [Title] FROM [Journal entries]";
            SqlDataAdapter log = new SqlDataAdapter(sa, JournalWebsite);
        }
    }
}
