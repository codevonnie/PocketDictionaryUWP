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
        public WordModel wordmodel { get; set; }

        public OtherViewModel(String input)
        {
            wordmodel = new WordModel();
            var wordInput = input;
            LoadData(wordInput);
            
        }

        public OtherViewModel() { }
        

        ObservableCollection<WordViewModel> _Word
           = new ObservableCollection<WordViewModel>();
        
                public ObservableCollection<WordViewModel> WordVM
                {
                    get { return _Word; }
                    set
                    {
                        SetProperty(ref _Word, value);
                        RaisePropertyChanged("_Word");
            
                    }
                }

        public async void LoadData(String input)
        {
            try {
                wordmodel = await Words.GetDefinitionAsync(input);
                if(wordmodel != null)
                {
                    var np = new WordViewModel(wordmodel);
                    _Word.Add(np);
                }
                else
                {
                    var dialog = new MessageDialog("Word not found - check your spelling");
                    await dialog.ShowAsync();
                }
                

            }
            catch
            {

            }
            
        }

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

