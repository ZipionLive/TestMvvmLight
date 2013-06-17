using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using GalaSoft.MvvmLight.Messaging;
using TestMvvmLight.Model;
using Microsoft.Phone.Shell;
//using TestMvvmLight.Model;

namespace TestMvvmLight.View
{
    public partial class ShowClientListView : PhoneApplicationPage
    {
        public ShowClientListView()
        {
            InitializeComponent();
            Messenger.Default.Register<Client>(this, ShowClient);
        }

        private void ShowClient(Client client)
        {
            PhoneApplicationService.Current.State["Client"] = client;
            NavigationService.Navigate(new Uri("/View/ShowClientView.xaml", UriKind.Relative));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //uncomment to disable selection
            //if (sender != null && sender.GetType() == typeof(ListBox))
            //    (sender as ListBox).SelectedIndex = -1;
        }
    }
}