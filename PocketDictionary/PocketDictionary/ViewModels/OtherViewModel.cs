//Main viewModel

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace ViewModels
{
    public class OtherViewModel : NotificationBase
    {
        //instance of wordmodel
        public WordModel wordmodel { get; set; }

        //constructor for viewmodel takes in user word for search
        public OtherViewModel(String input)
        {
            wordmodel = new WordModel(); //instantiate wordModel
            var wordInput = input; 
            LoadData(wordInput); //passes user input to LoadData method
        }

        public OtherViewModel() { }
        
        //create observablecollection to watch for changes in data
        ObservableCollection<WordViewModel> _Word
           = new ObservableCollection<WordViewModel>();
                
                //observable collection to reload data if changes are made
                public ObservableCollection<WordViewModel> WordVM
                {
                    get { return _Word; }
                    set
                    {
                        SetProperty(ref _Word, value);
                        RaisePropertyChanged("_Word");
            
                    }
                }

        //async method to make call to get data from api
        public async void LoadData(String input)
        {
            try {
                //call async method in Words.cs to get data and save response to wordmodel instance
                wordmodel = await Words.GetDefinitionAsync(input);

                //if the response has data add new values to observable collection
                if(wordmodel != null)
                {
                    var np = new WordViewModel(wordmodel);
                    _Word.Add(np);
                }
                else
                {
                    //if response is empty, word has not been found in api so alert user
                    var dialog = new MessageDialog("Word not found - check your spelling");
                    await dialog.ShowAsync();
                }
            }
            catch
            {

            }
            
        }
        //binding data for xaml page
        public String Type
        {
            get { return wordmodel.WordName; }
        }

        public String Definition
        {
            get { return wordmodel.WordName; }
        }

        public String Example
        {
            get { return wordmodel.WordName; }
        }

    }
}

