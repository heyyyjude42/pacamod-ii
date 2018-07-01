using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DataAccessLibrary;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PacaModII
{
    public sealed partial class HomeView : UserControl
    {
        public HomeView()
        {
            this.InitializeComponent();
        }

        private void XButton_AddData(object sender, RoutedEventArgs e)
        {
            //DataAccess.AddData(XInputBox.Text);
            //Output.ItemsSource = DataAccess.GetData();
        }

        private void ToggleTournamentInit(object sender, TappedRoutedEventArgs e)
        {
            XNewTournamentMaker.Visibility = Visibility.Visible;
            XNewOrLoadButtonPanel.Visibility = Visibility.Collapsed;
            XLoadedTournamentScreen.Visibility = Visibility.Collapsed;
        }

        private void ReturnToHome(object sender, TappedRoutedEventArgs e)
        {
            XNewTournamentMaker.Visibility = Visibility.Collapsed;
            XNewOrLoadButtonPanel.Visibility = Visibility.Visible;
            XLoadedTournamentScreen.Visibility = Visibility.Collapsed;
        }

        private void CreateNewTournament(object sender, TappedRoutedEventArgs e)
        {
            if (XRoundTextBox.Text == "" || XHostTextBox.Text == "") return;

            string fileName = XDatePicker.Date.Year + "-" + XDatePicker.Date.Month + "-" + XDatePicker.Date.Day
                              + "-" + XRoundTextBox.Text;
            DataAccess.InitializeDatabase(fileName.Replace(" ", string.Empty));
            XNewTournamentMaker.Visibility = Visibility.Collapsed;
            XNewOrLoadButtonPanel.Visibility = Visibility.Visible;
            XBigText.Text = "Now Scoring: " + XRoundTextBox.Text;
            XLoadedTournamentScreen.Visibility = Visibility.Visible;

            MainPage.Instance.OnTournamentLoaded();
        }

        //TODO: do this! should be just copying the file somewhere else
        private void ExportDatabase(object sender, TappedRoutedEventArgs e)
        {
            
        }
    }
}
