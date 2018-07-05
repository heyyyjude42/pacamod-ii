using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CertificateBuilder
{
    public sealed partial class CertificateOfAppreciationView : UserControl
    {
        public CertificateOfAppreciationView()
        {

            this.InitializeComponent();
        }

        private async void GenerateCertificatesStart()
        {
            var dylan = new AppreciationCertificateModel("2018", "Havana", "Dylan Kroft", "Rando Taiwanese",
                "January 1-2, 2018");
            var terran = new AppreciationCertificateModel("2018", "Havana", "Terran Kroft", "Rando Taiwanese",
                "January 1-2, 2018");
            var kk = new AppreciationCertificateModel("2018", "Havana", "Kevin Kuo", "Rando Taiwanese",
                "January 1-2, 2018");

            await CreateCertificate(dylan, 1.ToString());
            await CreateCertificate(terran, 2.ToString());
            await CreateCertificate(kk, 3.ToString());
        }

        private async Task CreateCertificate(AppreciationCertificateModel model, string name)
        {
            // make a copy of the read-only template
            var templateFile =
                await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri("ms-appx:///Assets/AppreciationCertTemplate.docx"));
            var copiedFile = await templateFile.CopyAsync(ApplicationData.Current.LocalFolder, "Certificates.docx", NameCollisionOption.ReplaceExisting);

            // load it into a new document
            var stream = await copiedFile.OpenReadAsync();
            var templateDoc = new WordDocument(stream.AsStream(), FormatType.Docx);

            // mailmerge
            string[] fieldNames = { "Year", "Round", "Name", "Title", "Date" };
            string[] fieldValues = { model.Year, model.Round, model.Name, model.Title, model.Date };
            templateDoc.MailMerge.Execute(fieldNames, fieldValues);

            // save the new certificate
            MemoryStream templateStream = new MemoryStream();
            templateDoc.Save(templateStream, FormatType.Docx);
            await SaveFile(templateStream, name + ".docx");

            // convert to PDF
            DocIORenderer renderer = new DocIORenderer();
            PdfDocument pdf = renderer.ConvertToPDF(templateDoc);
            renderer.Dispose();
            templateDoc.Close();

            // save the PDF
            MemoryStream outputStream = new MemoryStream();
            pdf.Save(outputStream);
            await SaveFile(outputStream, name + ".pdf");
            pdf.Close();
        }

        private async Task SaveFile(MemoryStream stream, string name)
        {
            StorageFolder local = ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(name, CreationCollisionOption.ReplaceExisting);

            IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite);
            Stream st = fileStream.AsStreamForWrite();
            st.SetLength(0);
            st.Write(stream.ToArray(), 0, (int) stream.Length);
            st.Flush();
            st.Dispose();
            fileStream.Dispose();

            //await Windows.System.Launcher.LaunchFileAsync(file);
        }

        private void XGenerate_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            GenerateCertificatesStart();
        }
    }
}
