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
        WordModel wordmodel;

        public OtherViewModel()
        {
            wordmodel = new WordModel();
            _SelectedIndex = -1;
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
            //set { SetProperty(ref _Word, value); }
        }

        public String Type
        {
            get { return wordmodel.WordName; }
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedWord)); }
            }
        }

        public WordViewModel SelectedWord
        {
            get { return (_SelectedIndex >= 0) ? _Word[_SelectedIndex] : null; }
        }


    }
}

