using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Util;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PacaModII.Views
{
    public sealed partial class RosterView : UserControl
    {
        public RosterView()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            {
                MainPage.Instance.TournamentLoaded += (s, args) => { XImportButton.IsEnabled = true; };
            };
        }

        private async void OpenFilePicker()
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".xls");
            picker.FileTypeFilter.Add(".xlsx");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                Roster.ImportRoster(file);
            }
        }

        private void XImportButton_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            OpenFilePicker();
        }
    }
}
