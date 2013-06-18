using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TestMvvmLight.Model;

namespace TestMvvmLight
{
    public class GoToPageMessage
    {
        public string PageName { get; private set; }
        public Client SelectedClient { get; private set; }

        public GoToPageMessage(string PageName, Client SelectedClient)
        {
            this.PageName = PageName;
            this.SelectedClient = SelectedClient;
        }
    }
}
