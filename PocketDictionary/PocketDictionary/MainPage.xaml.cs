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
using ViewModels;
using Windows.UI.Popups;
using System.Net.NetworkInformation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PocketDictionary
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            //check if device is connected to internet
            bool isInternetConnected = NetworkInterface.GetIsNetworkAvailable();

            //if no connection is found call method to alert user to connect to internet
            if (!isInternetConnected)
            {
                checkConnection();
            }

            input = "dictionary"; //dummy value for collection
            this.InitializeComponent();
            
          }
        //displays message to user if no internet connection is found
        private async void checkConnection()
        {
            var dialog = new MessageDialog("Please connect to the internet to use app");
            await dialog.ShowAsync();

        }
        
        public OtherViewModel WordModel { get; set; }
        public static String input;

        //event listener for when user clicks search button
        private async void searchBtn_Click(object sender, RoutedEventArgs e)
        {

            bool isInternetConnected = NetworkInterface.GetIsNetworkAvailable();

            //if user tries to search while not connected to internet, alert them they need a connection
            if (!isInternetConnected)
            {
                checkConnection();
            }
            //convert word to lowercase for api
            input = inputText.Text.ToLower();

            //check input is only alphabet characters
            var check = IsAllAlphabetic(input);

            //if check is true, start call to api
            if (check)
            {
                //create new view model based on user input
                WordModel = new OtherViewModel(input);
                //update observable collection
                Bindings.Update();
            }
            //if chars entered are not all alphabet characters, alert user
            else
            {
                var dialog = new MessageDialog("Please only use alphabet characters");
                await dialog.ShowAsync();
            }
            check = false;

        }

        //check for character types in input value
        bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                //if the character is not a letter return false to trigger user alert
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }


    }
}

