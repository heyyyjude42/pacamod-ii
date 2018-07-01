using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ScholarModel
    {
        public int ScupID { get; }
        public int Index { get; }
        public string Country { get; }
        public string School { get; }
        public int TeamID { get; }
        public int Position { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int DayOfBirth { get; }
        public int MonthOfBirth { get; }
        public int YearOfBirth { get; }
        //maybe an enum instead?
        public string Sex { get; }

        public ScholarModel(int id, int index, string country, string school, int teamID, int pos, string firstname,
            string lastname, int dd, int mm, int yy, string sex)
        {
            ScupID = id;
            Index = index;
            Country = country;
            School = school;
            TeamID = teamID;
            Position = pos;
            FirstName = firstname;
            LastName = lastname;
            DayOfBirth = dd;
            MonthOfBirth = mm;
            YearOfBirth = yy;
            Sex = sex;
        }
    }
}
