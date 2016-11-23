using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class OtherViewModel : NotificationBase
    {
        public WordModel wordmodel { get; set; }
        //public string wordInput { get; set; }



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
                    }
                }

        public async void LoadData(String input)
        {
            try {
                wordmodel = await Words.GetDefinitionAsync(input);
                var np = new WordViewModel(wordmodel);
                _Word.Add(np);

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

