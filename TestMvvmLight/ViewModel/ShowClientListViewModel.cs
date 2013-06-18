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
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using TestMvvmLight.Model;
using TestMvvmLight.Model.Design;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

namespace TestMvvmLight.ViewModel
{
    public class ShowClientListViewModel : ViewModelBase
    {
        #region Private fields
        private List<Client> _clientList;
        private Client _selection;
        #endregion

        #region Properties
        public List<Client> ClientList
        {
            get { return _clientList; }
            set { NotifyPropertyChanged(ref _clientList, value); }
        }

        public Client Selection
        {
            get { return _selection; }
            set { NotifyPropertyChanged(ref _selection, value); }
        }

        public ICommand ShowDetailsCommand { get; set; }
        public ICommand ToggleCommand { get; set; }
        public ICommand ElementSelectionCommand { get; set; }
        #endregion

        #region Constructor
        public ShowClientListViewModel(IClientService service)
        {
            ClientList = service.LoadList();

            ShowDetailsCommand = new RelayCommand<Client>(ShowDetails, CanExecuteShowDetails);
            ToggleCommand = new RelayCommand<Client>(Toggle);
            ElementSelectionCommand = new RelayCommand<SelectionChangedEventArgs>(ElementSelection);
        }
        #endregion

        #region NotifyPropertyChanged
        private bool NotifyPropertyChanged<T>(ref T variable, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(variable, newValue))
                return false;

            variable = newValue;
            RaisePropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region Commanding
        private void ShowDetails(Client client)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} {1}", client.FirstName, client.LastName));
            sb.AppendLine(string.Format("{0} years old, {1} client", client.Age, (client.IsGoodClient) ? "good" : "bad"));
            MessageBox.Show(sb.ToString());
        }

        private void Toggle(Client client)
        {
            client.IsGoodClient = !client.IsGoodClient;
            CheckCommandState();
        }

        private void ElementSelection(SelectionChangedEventArgs e)
        {
            if (Selection != null)
            {
                Messenger.Default.Send(Selection);
                Selection = null;
            }
        }

        private bool CanExecuteShowDetails(Client client)
        {
            if (client == null) return false;
            return client.IsGoodClient;
        }

        private void CheckCommandState()
        {
            if (ShowDetailsCommand != null) (ShowDetailsCommand as RelayCommand<Client>).RaiseCanExecuteChanged();
        }
        #endregion

    }
}