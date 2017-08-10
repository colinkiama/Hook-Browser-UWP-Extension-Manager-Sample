using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace hookBrowser
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            AppData.ExtensionManager.Initialize();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            sideMenuFrame.Navigate(typeof(ExtensionsTab));
        }
        private async void goButton_Click(object sender, RoutedEventArgs e)
        {
            //Only running the first extenion in the list in this case. 
            List<hookBrowser.Extension> extensions = AppData.ExtensionManager.Extensions.ToList();
            if (extensions.Count > 0)
            {
            var extn = extensions.First();

            var color = await extn.InvokeLoad("Parameter that could be passed into the app service as any object with some changes");
            try
            {
                var colourArgb = (int[])color;
                byte a = (byte)colourArgb[0];
                byte r = (byte)colourArgb[1];
                byte g = (byte)colourArgb[2];
                byte b = (byte)colourArgb[3];
                myGrid.Background = new SolidColorBrush(Color.FromArgb(a, r, g, b));
            }
            catch (Exception)
            {

                
            }

            }
        }

       
    }
}
