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
<<<<<<< HEAD
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
=======
        public WordModel wordmodel { get; set; }

        //private List<WordModel> _wordModel = new List<WordModel>();

        //WordModel wordmodel;

        

        public OtherViewModel()
        {
            wordmodel = new WordModel();
            LoadData();
            
>>>>>>> refs/remotes/origin/Restructure
        }
        

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

        public async void LoadData()
        {
<<<<<<< HEAD
            get { return _Word; }
            set { SetProperty(ref _Word, value);
                RaisePropertyChanged("WordModel");
            }
=======
            try {
                wordmodel = await Words.GetDefinitionAsync();
                var np = new WordViewModel(wordmodel);
                _Word.Add(np);

            }
            catch
            {

            }
            
>>>>>>> refs/remotes/origin/Restructure
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

