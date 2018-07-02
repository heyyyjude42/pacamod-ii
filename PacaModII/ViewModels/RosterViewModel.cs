using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using PacaModII.Models;
using PacaModII.Util;

namespace PacaModII.ViewModels
{
    public class RosterViewModel
    {
        public ObservableCollection<ScholarModel> JuniorRoster { get; set; } = new ObservableCollection<ScholarModel>();
        public ObservableCollection<ScholarModel> SeniorRoster { get; set; } = new ObservableCollection<ScholarModel>();

        public RosterViewModel()
        {

        }

        public RosterViewModel(ObservableCollection<ScholarModel> jr, ObservableCollection<ScholarModel> sr)
        {
            JuniorRoster = jr;
            SeniorRoster = sr;
        }
    }
}
