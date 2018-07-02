using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;
using Syncfusion.XlsIO;

namespace Util
{
    public enum Division
    {
        Skittles,
        Junior,
        Senior
    }

    /// <summary>
    /// This class is responsible for communicating with the database and returning queries and so forth.
    /// </summary>
    public static class Roster
    {
        public static async Task ImportRoster(StorageFile file)
        {
            ExcelEngine engine = new ExcelEngine();
            IApplication application = engine.Excel;
            IWorkbook workbook = await application.Workbooks.OpenAsync(file);
            IWorksheet juniorSheet = workbook.Worksheets["Junior"];
            IWorksheet seniorSheet = workbook.Worksheets["Senior"];

            if (juniorSheet == null)
                throw new Exception("No worksheet named \"Junior\" found. Try again, buddy.");
            if (seniorSheet == null)
                throw new Exception("No worksheet named \"Senior\" found. Try again, buddy.");

            Debug.WriteLine(juniorSheet.UsedRange);
        }
    }
}
