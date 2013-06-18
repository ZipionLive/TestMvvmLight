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
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using TestMvvmLight.Model;
using System.Runtime.CompilerServices;
using Microsoft.Phone.Shell;

namespace TestMvvmLight.ViewModel
{
    public class ShowClientViewModel : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private SolidColorBrush _isGoodClient;

        public string FirstName
        {
            get { return _firstName; }
            set { NotifyPropertyChanged(ref _firstName, value); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { NotifyPropertyChanged(ref _lastName, value); }
        }

        public int Age
        {
            get { return _age; }
            set { NotifyPropertyChanged(ref _age, value); }
        }

        public SolidColorBrush IsGoodClient
        {
            get { return _isGoodClient; }
            set { NotifyPropertyChanged(ref _isGoodClient, value); }
        }

        public ShowClientViewModel()
        {
            Messenger.Default.Register<Client>(this, UpdateClient);
            Client client = PhoneApplicationService.Current.State["Client"] as Client;
            UpdateClient(client);
        }

        private void UpdateClient(Client client)
        {
            FirstName = client.FirstName;
            LastName = client.LastName;
            Age = client.Age;
            IsGoodClient = (client.IsGoodClient)
                ? new SolidColorBrush(Color.FromArgb(100, 0, 255, 0))
                : new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
        }

        private bool NotifyPropertyChanged<T>(ref T variable, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(variable, newValue))
                return false;

            variable = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
