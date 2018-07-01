using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        private static string _currentDatabaseFileName;

        public static void InitializeDatabase(String fileName)
        {
            _currentDatabaseFileName = fileName;

            using (SqliteConnection db =
                new SqliteConnection(GetFileName()))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                                      "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                                      "Text_Entry NVARCHAR(2048) NULL)";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }

        public static void AddData(string inputText)
        {
            using (SqliteConnection db = new SqliteConnection(GetFileName()))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Entry);";
                insertCommand.Parameters.AddWithValue("@Entry", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        public static List<String> GetData()
        {
            List<String> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection(GetFileName()))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();
            }

            return entries;
        }

        private static string GetFileName()
        {
            return "Filename=" + _currentDatabaseFileName + ".db";
        }
    }
}
