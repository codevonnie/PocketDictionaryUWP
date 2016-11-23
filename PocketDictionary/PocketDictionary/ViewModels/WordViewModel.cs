using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModels
{
    public class WordViewModel : NotificationBase<WordModel>
    {
        public WordViewModel(WordModel myWords = null) : base(myWords) { }
        public String Type
        {
            get { return This.type; }
            set { SetProperty(This.type, value, () => This.type = value); }
        }
        public String Definition
        {
            get { return This.definition; }
            set { SetProperty(This.definition, value, () => This.definition = value); }
        }
        public String Example
        {
            get { return This.example; }
            set { SetProperty(This.example, value, () => This.example = value); }
        }
    }
}
