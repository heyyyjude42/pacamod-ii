﻿using System;
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
        public event EventHandler TournamentLoaded;

        // do we really need this?
        public event EventHandler TournamentUnloaded;

        public MainPage()
        {
            this.InitializeComponent();
            Instance = this;
        }

        public void OnTournamentLoaded()
        {
            TournamentLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void OnTournamentUnloaded()
        {
            TournamentUnloaded?.Invoke(this, EventArgs.Empty);
        }
    }
}