using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacaModII.Models;

namespace PacaModII
{
    /// <summary>
    /// A kind-of model. More meant for consolidation, especially as more scores and tables gets added. Also will be used once we load saved databases into memory.
    /// </summary>
    public class Roster
    {
        public enum Division
        {
            Skittles,
            Junior,
            Senior
        }

        public ObservableCollection<ScholarModel> JuniorRoster { get; set; } = new ObservableCollection<ScholarModel>();
        public ObservableCollection<ScholarModel> SeniorRoster { get; set; } = new ObservableCollection<ScholarModel>();
    }
}
