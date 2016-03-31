using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Networking.PushNotifications;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ECGCAT_IoT_Notification_Client
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private SolidColorBrush redBrush = new SolidColorBrush(Windows.UI.Colors.Red);
        private SolidColorBrush greenBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        
        public MainPage()
        {
            this.InitializeComponent();
            this.Initialize();            
        }


       private async void appActivatedAsync(object sender, IActivatedEventArgs e)
        {
            //var toastArgs = e as ToastNotificationActivatedEventArgs;
            //var arguments = toastArgs.Argument;

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, delegate
            {
                StatusButton.Fill = redBrush;
                Icon.Symbol = Symbol.Important;
            });
        }
        private void Initialize()
        {
            // Clear all existing notifications
            ToastNotificationManager.History.Clear();

            // Listen to activation event
            (Application.Current as App).Activated = new EventHandler<IActivatedEventArgs>(appActivatedAsync);

        }
    }
}
