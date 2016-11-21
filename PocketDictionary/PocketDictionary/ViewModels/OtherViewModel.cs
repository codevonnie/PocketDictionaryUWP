using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public class OtherViewModel : NotificationBase
    {
        //public WordModel wordmodel { get; set; }
        WordModel wordmodel;
/*
        public async Task<OtherViewModel> StartAsyncView()
        {
            this.wordmodel = await new WordModel().StartAsync();
            foreach (var word in wordmodel.Words)
            {
                var np = new WordViewModel(word);
                _Word.Add(np);
            }
            return this;
        }
        */
        public OtherViewModel()
        {
            wordmodel = new WordModel();

            // Load the database
            foreach (var word in wordmodel.Words)
            {
                var np = new WordViewModel(word);
                _Word.Add(np);
            }
        }
        

        ObservableCollection<WordViewModel> _Word
           = new ObservableCollection<WordViewModel>();
        public ObservableCollection<WordViewModel> Words
        {
            get { return _Word; }
            set { SetProperty(ref _Word, value);
                RaisePropertyChanged("WordModel");
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

