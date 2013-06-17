﻿using System;
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

namespace TestMvvmLight.Model
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsGoodClient { get; set; }

        public Client(string FirstName, string LastName, int Age, bool IsGoodClient)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.IsGoodClient = IsGoodClient;
        }
    }

    public interface IClientService
    {
        Client Load();
        List<Client> LoadList();
    }

    public class ClientService : IClientService
    {
        public Client Load()
        {
            return new Client("Alexandre", "Engelhardt", 29, true);
        }


        public List<Client> LoadList()
        {
            return new List<Client>
            {
                new Client("Alexandre", "Engelhardt", 29, true),
                new Client("Simon", "Encev", 27, false),
                new Client("Marilyn", "Martin", 24, true),
                new Client("Florence", "Harrer", 25, true)
            };
        }
    }
}

namespace TestMvvmLight.Model.Design
{
    public class DesignClientService : IClientService
    {
        public Client Load()
        {
            return new Client("Alexandre", "Engelhardt", 29, true);
        }

        public List<Client> LoadList()
        {
            return new List<Client>
            {
                new Client("Alexandre", "Engelhardt", 29, true),
                new Client("Simon", "Encev", 27, false),
                new Client("Marilyn", "Martin", 24, true),
                new Client("Florence", "Harrer", 25, true)
            };
        }
    }
}
