using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace JournalLibrary
{
    public class Access
    {
        //Connection (Like a bridge)
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";

        //Connecting to your database
        static SqlConnection JournalWebsite = new SqlConnection(connection);

        //Log in method with iputting username and password as the parameters. At the end of this method...it will receive either a true or false value.
        public static bool login(string username, string password)
        {
            //SQL querey to SELECT username, and password with WHERE coditions
            string SELECT = $"SELECT [UserName], [Password] FROM [User info] WHERE [UserName] = '{username}' AND [Password] = '{password}'";

            /*Used the data adapter to fill the upcoming dataset. REMEMBER, data adapter is only to fill data sets or tables. 
            Cannot be used to execute other commands.*/
            SqlDataAdapter log = new SqlDataAdapter(SELECT, JournalWebsite);

            //Created a dataset object to store my data when the query is executed
            DataSet data = new DataSet();

            //The data in the log then fills the "data" dataset
            log.Fill(data);

            //The reason for a try statement is because if there is no rows. An SQL exception would be thrown.
            try
            {
            /*This statement looks tricky but its simple..."data" is the dataset that now has all the data that the previous 
            query updated. Then it is accessed to its Table at element 0. Its 0 because in an array's element, 0 is 1. Then it is accessed to its 
            Rows at element 0 with the SQL column name. Then it is converted into a string. The string is stored in Susername and Spassword.*/
                string Susername = data.Tables[0].Rows[0]["UserName"].ToString();
                string Spassword = data.Tables[0].Rows[0]["Password"].ToString();

                //Operation is complete. There is a row. Return true.
                return true;
            }
            /*The statement will catch the SQL exception when there are no rows. Displaying an error message is unnecessary.
             Therefore only putting the Exception.*/
            catch(Exception)
            {
                //There are no rows. Return false.
                return false;
            }
 
        }

        /*Register method with iputting username and password as the parameters. At the end of this method...it will receive either 0, 1, or 2.
         Think about as 0 is when there is a row, meaning that the username is taken. 1 is when there is a blank password. 2 when the operation is complete*/
        public static int register(string username, string password)
        {
            //SQL querey to SELECT username with WHERE codition.
            string SELECT = $"SELECT [UserName] FROM [User info] WHERE [UserName] = '{username}'";
            //SQL query to INSERT new username and password into the database.
            string ADD = $"INSERT INTO[User info] ([UserName], [Password]) VALUES('{username}', '{password}')";

            /*Used the data adapter to fill the upcoming dataset. REMEMBER, data adapter is only to fill data sets or tables. 
           Cannot be used to execute other commands.*/
            SqlDataAdapter reg = new SqlDataAdapter(SELECT, JournalWebsite);

            //Created a dataset object to store my data when the query is executed
            DataSet data = new DataSet();

            //The data in reg then fills the "data" dataset
            reg.Fill(data);

            //The reason for a try statement is because if there is no rows. An SQL exception would be thrown.
            try
            {
                /*This statement looks tricky but its simple..."data" is the dataset that now has all the data that the previous 
                query updated. Then it is accessed to its Table at element 0. Its 0 because in an array's element, 0 is 1. Then it is accessed to its 
                Rows at element 0 with the SQL column name. Then it is converted into a string. The string is stored in Susername and Spassword.*/
                string Susername = data.Tables[0].Rows[0]["UserName"].ToString();

                //There is a row. Return 0.
                return 0;
            }
            /*The statement will catch the SQL exception when there are no rows. Displaying an error message is unnecessary.
              Therefore only putting the Exception.*/
            catch (Exception)
            {
                //If the new password is blank or less than 1. Return 1.
                if (password == "" || password.Length < 1)
                {
                    //Return 1.
                    return 1;
                }
                //If everything is okay. Execute the following code.
                else
                {
                    //Stores ADD query into the database as a command.
                    SqlCommand command = new SqlCommand(ADD, JournalWebsite);

                    //Need to open the database in order to execute command.
                    JournalWebsite.Open();

                    //Execute command.
                    command.ExecuteNonQuery();

                    //Cannot finish without closing your database. Close databse.
                    JournalWebsite.Close();

                    //Operation is complete. Return 2.
                    return 2;
                }
                //There are 3 diffrent routes it can go. In a bool, there is only true or false, 2. Therefore using a int to return to.
            }
             
        }
    }
}
