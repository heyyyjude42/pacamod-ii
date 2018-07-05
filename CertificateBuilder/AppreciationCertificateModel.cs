using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificateBuilder
{
    class AppreciationCertificateModel
    {
        public string Year { get; set; }
        public string Round { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }

        public AppreciationCertificateModel(string year, string round, string name, string title, string date)
        {
            Year = year;
            Round = round;
            Name = name;
            Title = title;
            Date = date;
        }
    }
}
