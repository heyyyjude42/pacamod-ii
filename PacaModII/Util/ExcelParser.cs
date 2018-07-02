using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using PacaModII.Models;
using Syncfusion.XlsIO;

namespace PacaModII.Util
{
    /// <summary>
    /// Use this class to pull data out of Excel files.
    /// </summary>
    public static class ExcelParser
    {
        public static async Task<ObservableCollection<ScholarModel>> ParseForScholars(StorageFile file, Roster.Division div)
        {
            var roster = new ObservableCollection<ScholarModel>();

            ExcelEngine engine = new ExcelEngine();
            IApplication application = engine.Excel;
            IWorkbook workbook = await application.Workbooks.OpenAsync(file);
            IWorksheet sheet = workbook.Worksheets[div.ToString()];

            if (sheet == null)
                throw new Exception("No worksheet named " + div + " found. Try again, buddy.");

            int row = 2;
            // basically keep going until there's no text in the row
            while (sheet[row, 2].DisplayText.Length > 1)
            {
                int ScupID = (int) sheet[row, 4].Number * 10 + (int) sheet[row, 5].Number;
                int Index = (int) sheet[row, 1].Number;
                string Country = sheet[row, 2].Text;
                string School = sheet[row, 3].Text;
                int TeamID = (int) sheet[row, 4].Number;
                int Position = (int) sheet[row, 5].Number;
                string FirstName = sheet[row, 6].Text;
                string LastName = sheet[row, 7].Text;
                string Sex = sheet[row, 12].Text;

                var newScholar = new ScholarModel(ScupID, Index, Country, School, TeamID, Position, FirstName, LastName,
                    Sex, div);
                roster.Add(newScholar);

                row++;
            }

            return roster;
        }
    }
}
