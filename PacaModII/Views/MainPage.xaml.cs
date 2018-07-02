using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PacaModII.Util;
using PacaModII.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PacaModII
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // singleton
        public static MainPage Instance;
        private Roster _masterRoster = new Roster();
        public event EventHandler TournamentLoaded;

        public MainPage()
        {
            this.InitializeComponent();
            Instance = this;
            UpdateViewModels();
        }

        /// <summary>
        /// Sets up the ViewModels for all the views, based off of the master roster.
        /// </summary>
        private void UpdateViewModels()
        {
            XRosterView.ViewModel = new RosterViewModel(_masterRoster.JuniorRoster, _masterRoster.SeniorRoster);
        }

        public void OnTournamentLoaded()
        {
            TournamentLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void ShowDialog(string title, string content, string buttonText)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = buttonText
            };

            dialog.ShowAsync();
        }

        public async Task ImportRoster(StorageFile file)
        {
            _masterRoster.JuniorRoster = await ExcelParser.ParseForScholars(file, Roster.Division.Junior);
            _masterRoster.SeniorRoster = await ExcelParser.ParseForScholars(file, Roster.Division.Senior);
            UpdateViewModels();
        }
    }
}
