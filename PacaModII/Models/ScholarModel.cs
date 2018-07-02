using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacaModII.Util;

namespace PacaModII.Models
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
        //maybe an enum instead?
        public string Sex { get; }
        public Roster.Division Division { get; }

        /// <summary>
        /// Make a new model for a scholar.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="index"></param>
        /// <param name="country"></param>
        /// <param name="school"></param>
        /// <param name="teamID"></param>
        /// <param name="pos"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="sex"></param>
        /// <param name="division"></param>
        public ScholarModel(int id, int index, string country, string school, int teamID, int pos, string firstname,
            string lastname, string sex, Roster.Division division)
        {
            ScupID = id;
            Index = index;
            Country = country;
            School = school;
            TeamID = teamID;
            Position = pos;
            FirstName = firstname;
            LastName = lastname;
            Sex = sex;
            Division = division;
        }
    }
}
