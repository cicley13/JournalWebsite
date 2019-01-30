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
        //Connection (Like a bridge)
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=JournalWebsite;Integrated Security=True";
        //Connecting to your database
        static SqlConnection JournalWebsite = new SqlConnection(connection);
        //edit profile method. Two original inputs with two new input paramenters. At the end of this method...it will receive either a true or false value.
        public static bool editProfile(string username, string password, string newusername, string newpassword)
        {
            //SQL querey to SELECT loginid, username, and password with WHERE coditions
            string SELECT = $"SELECT [LogInID], [UserName], [Password] FROM [User info] WHERE [UserName] = '{username}' AND [Password] = '{password}'";

            /*Used the data adapter to fill the upcoming dataset. REMEMBER, data adapter is only to fill data sets or tables. 
             Cannot be used to execute other commands.*/
            SqlDataAdapter edit = new SqlDataAdapter(SELECT, JournalWebsite);

            //Created a data set object to store my data when the query is executed
            DataSet result = new DataSet();

            //The data in the edit then fills the result data set
            edit.Fill(result);

            /*This statement looks tricky but its simple..."result" is the dataset that now has all the data that the previous 
             query updated. Then it is accessed to its Table at element 0. Its 0 because arrays element 0 is 1. then it is accessed to its 
             Rows at element 0 with the SQL column name. Then it is converted into a string. The string is stored in Susername. This is the original 
             username data.*/
            string Susername = result.Tables[0].Rows[0]["UserName"].ToString();

            //If Susername (original) is equal to the new username. Return false
            if (Susername == newusername)
            {
                return false;
            }
            //If the new password is blank or less than 1. Return false.
            else if (newpassword == "" || newpassword.Length < 1)
            {
                return false;
            }
            //If everything is okay. Execute the following code.
            else
            {
                //The statement allows the logInId to be stored in slogInID. Need it for the upcoming query.
                string SlogID = result.Tables[0].Rows[0]["LogInId"].ToString();

                //A query that allows the user to upadte its username and password according to its logInID
                string UPDATE = $"UPDATE [User info] SET [UserName] = '{newusername}', [Password] = '{newpassword}' WHERE [LogInID] ={SlogID}";

                //Stores UPDATE query into the database as a command.
                SqlCommand command = new SqlCommand(UPDATE, JournalWebsite);

                //Need to open the database in order to execute command.
                JournalWebsite.Open();

                //Execute command.
                command.ExecuteNonQuery();

                //Cannot finish without closing your database. Close databse.
                JournalWebsite.Close();

                //Operation is complete. Return true.
                return true;
            }
        }
    }
}
