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

        public void Stack(object sender)
        {
            JournalWebsite.Open();
            // Calling the Stored Procedure
            
            
            SqlDataAdapter da = new SqlDataAdapter("select Titles from Journal Entries", connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Titles");
            Titles.ItemsSource = ds.Tables[Titles].DefaultView;

            JournalWebsite.Close();
        }
            catch (Exception ex)
            {

            }
            finally
            {
                
            }

        }

}
