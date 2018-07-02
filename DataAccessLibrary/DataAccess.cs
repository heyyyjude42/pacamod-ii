using System;
using System.Collections.Generic;
using System.Diagnostics;
using DataAccessLibrary.Models;
using Microsoft.Data.Sqlite;

namespace DataAccessLibrary
{
    public static class DataAccess
    {
        private static string _currentDatabaseFileName;
        
        /// <summary>
        /// Call this method to initialize a new database for the current tournament. Only does Junior and Senior, not Skittles.
        /// </summary>
        /// <param name="fileName"></param>
        public static void InitializeDatabase(String fileName)
        {
            _currentDatabaseFileName = fileName;

            using (SqliteConnection db =
                new SqliteConnection(GetFileName()))
            {
                db.Open();
                InitializeDivision(Division.Junior, db);
                InitializeDivision(Division.Senior, db);
            }
        }

        /// <summary>
        /// Helper method for initializing the databases for a whole division
        /// </summary>
        /// <param name="division"></param>
        /// <param name="db"></param>
        private static void InitializeDivision(Division division, SqliteConnection db)
        {
            String rosterCommand = "CREATE TABLE IF NOT " +
                                     "EXISTS " + division + "Roster (ScupID INTEGER PRIMARY KEY, " +
                                     "RegIndex INTEGER, Country TEXT, School TEXT, TeamID INTEGER, Position INTEGER, " +
                                     "FirstName TEXT, LastName TEXT, DD INTEGER, MM INTEGER, YY INTEGER, Sex TEXT)";

            String indScoresCommand = "CREATE TABLE IF NOT " +
                                        "EXISTS " + division + "IndividualScores (ScupID INTEGER PRIMARY KEY, " +
                                        "C_Arts INTEGER DEFAULT 0, C_Hist INTEGER DEFAULT 0, C_Lit INTEGER DEFAULT 0, C_Sci INTEGER DEFAULT 0, C_SStud INTEGER DEFAULT 0, C_SpecA INTEGER DEFAULT 0, " +
                                        "Challenge INTEGER DEFAULT 0, Writing INTEGER DEFAULT 0, Debate INTEGER DEFAULT 0, Overall INTEGER DEFAULT 0)";

            String teamScoresCommand = "CREATE TABLE IF NOT " +
                                         "EXISTS " + division + "TeamScores (Team INTEGER PRIMARY KEY, " +
                                         "Challenge INTEGER DEFAULT 0, Writing INTEGER DEFAULT 0, Debate INTEGER DEFAULT 0, Bowl INTEGER DEFAULT 0, Overall INTEGER DEFAULT 0)";


            // TODO: do we initialize detailed debate/bowl/etc tables here as well? Probably?

            SqliteCommand createRoster = new SqliteCommand(rosterCommand, db);
            SqliteCommand createInd = new SqliteCommand(indScoresCommand, db);
            SqliteCommand createTeam = new SqliteCommand(teamScoresCommand, db);

            createRoster.ExecuteReader();
            createInd.ExecuteReader();
            createTeam.ExecuteReader();
        }

        /// <summary>
        /// Use this to add a scholar to the roster.
        /// </summary>
        /// <param name="scholar"></param>
        /// <param name="division"></param>
        public static void AddToRoster(ScholarModel scholar, Division division)
        {
            using (SqliteConnection db = new SqliteConnection(GetFileName()))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                //(ScupID INTEGER PRIMARY KEY, " +
                //"Index INTEGER, Country STRING, School STRING, TeamID INTEGER, Position INTEGER, " +
                //    "FirstName STRING, LastName STRING, DD INTEGER, MM INTEGER, YY INTEGER, Sex STRING)";
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Roster VALUES (@ScupID, @Index, @Country, @School, @TeamID, " +
                                            "@Pos, @First, @Last, @DD, @MM, @YY, @Sex)";
                insertCommand.Parameters.AddWithValue("@ScupID", scholar.ScupID);
                insertCommand.Parameters.AddWithValue("@Index", scholar.Index);
                insertCommand.Parameters.AddWithValue("@Country", scholar.Country);
                insertCommand.Parameters.AddWithValue("@School", scholar.School);
                insertCommand.Parameters.AddWithValue("@TeamID", scholar.TeamID);
                insertCommand.Parameters.AddWithValue("@Pos", scholar.Position);
                insertCommand.Parameters.AddWithValue("@First", scholar.FirstName);
                insertCommand.Parameters.AddWithValue("@Last", scholar.LastName);
                insertCommand.Parameters.AddWithValue("@DD", scholar.DayOfBirth);
                insertCommand.Parameters.AddWithValue("@MM", scholar.MonthOfBirth);
                insertCommand.Parameters.AddWithValue("@YY", scholar.YearOfBirth);
                insertCommand.Parameters.AddWithValue("@Sex", scholar.Sex);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }

        /// <summary>
        /// Should theoretically be only called once to load everything into memory.
        /// </summary>
        /// <returns></returns>
        public static List<String> GetData()
        {
            // TODO: make a new class to not have strings
            List<String> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection(GetFileName()))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT Text_Entry from Roster", db);

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
