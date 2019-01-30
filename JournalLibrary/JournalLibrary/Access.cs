﻿using System;
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
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog = JournalWebsite; Integrated Security = True";
        static SqlConnection JournalWebsite = new SqlConnection(connection);

        public static bool login(string username, string password)
        {
            string SELECT = $"SELECT [UserName], [Password] FROM [User info] WHERE [UserName] = '{username}' AND [Password] = '{password}'";

            SqlDataAdapter log = new SqlDataAdapter(SELECT, JournalWebsite);

            DataTable table = new DataTable();

            log.Fill(table);

            if (table.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool register(string username, string password)
        {
            string SELECT = $"SELECT [UserName] FROM [User info] WHERE [UserName] = '{username}'";
            string ADD = $"INSERT INTO[User info] ([UserName], [Password]) VALUES(@username, @pass)";

            SqlDataAdapter reg = new SqlDataAdapter(SELECT, JournalWebsite);

            DataTable table = new DataTable();

            reg.Fill(table);

            if (table.Rows.Count == 1)
            {
                return false;
            }
            else if (password == "" || password.Length < 1)
            {
                return false;
            }
            else
            {
                SqlCommand command = new SqlCommand(ADD, JournalWebsite);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@pass", password);
                JournalWebsite.Open();
                command.ExecuteNonQuery();
                JournalWebsite.Close();
                return true;
                
            }
        }
    }
}
