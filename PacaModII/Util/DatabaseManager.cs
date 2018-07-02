using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;
using PacaModII.Models;
using Syncfusion.XlsIO;

namespace PacaModII.Util
{

    /// <summary>
    /// This class is responsible for communicating with the database and the app to make data interactions simpler. 
    /// </summary>
    public static class DatabaseManager
    {
        public static void ImportRoster(Collection<ScholarModel> roster)
        {
            foreach (var scholar in roster)
            {
                DataAccess.AddScholar(scholar);
            }
        }
    }
}
