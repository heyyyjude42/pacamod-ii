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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CertificateBuilder
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDU0MEAzMTM2MmUzMjJlMzBUYUZuMHp2Y0VBS0lEUFVnZ3VoaFFEQnNuQlZzazJqcllrN1pmbjZaNmpjPQ==;NDU0MUAzMTM2MmUzMjJlMzBwRVN2Wk1oYVA0bFdWbjFCdFdaMmJ5bitMcmw0dzVPVTAvOG5HMjhFZW00PQ==;NDU0MkAzMTM2MmUzMjJlMzBscnBnUDZyTUtQYnQ2U0gzd3EwVG15UUtkQWU5M29QejlOWWRNb1c4cENBPQ==;NDU0M0AzMTM2MmUzMjJlMzBNRkNZb3krTXhaT00wU3NubWQvQVZmRzJweTVjQWV5OUdIU0Y0a1MxWEhBPQ==");
        }
    }
}
