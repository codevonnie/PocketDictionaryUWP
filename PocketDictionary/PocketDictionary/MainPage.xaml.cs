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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PocketDictionary
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            input = "dictionary"; //dummy value for collection
            this.InitializeComponent();

        }
        
        public OtherViewModel WordModel { get; set; }
        public static String input;

        //event listener for when user clicks search button
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            //convert word to lowercase for api
            input = inputText.Text.ToLower();
            //create new view model based on user input
            WordModel = new OtherViewModel(input);
            //update observable collection
            Bindings.Update();
            
        }
    }
}

