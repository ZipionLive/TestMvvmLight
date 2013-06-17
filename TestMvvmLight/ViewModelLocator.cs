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
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using TestMvvmLight.Model;
using TestMvvmLight.Model.Design;
using TestMvvmLight.ViewModel;

namespace TestMvvmLight
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
                SimpleIoc.Default.Register<IClientService, DesignClientService>();
            else
                SimpleIoc.Default.Register<IClientService, ClientService>();

            SimpleIoc.Default.Register<ShowClientViewModel>();
            SimpleIoc.Default.Register<ShowClientListViewModel>();
        }

        public ShowClientViewModel ShowClientVM
        {
            get { return ServiceLocator.Current.GetInstance<ShowClientViewModel>(); }
        }

        public ShowClientListViewModel ShowClientListVM
        {
            get { return ServiceLocator.Current.GetInstance<ShowClientListViewModel>(); }
        }
    }
}