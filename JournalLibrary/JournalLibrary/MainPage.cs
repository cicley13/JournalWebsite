using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JournalLibrary
{
    public class MainPage
    {

        static string connection = "Data Source=DESKTOP-DJU5C3P\\SQLEXPRESS;Initial Catalog=Journal website;Integrated Security=True";

        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public static void Titles()
        {

            string SELECT = $"SELECT [Titles] FROM [Journal entires] WHERE [LogInID]";

            SqlDataAdapter show = new SqlDataAdapter(SELECT, JournalWebsite);


            DataSet data = new DataSet();


            show.Fill(data);



            JournalWebsite.Open();

            show.SqlDataAd();

            JournalWebsite.Close();
        }
    }
}
