//WordModel class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Data.Json;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;

namespace Model
{
    public class WordModel
    {
        //getters/setters for WordModel attributes
        public string type { get; set; }
        public string definition { get; set; }
        public string example { get; set; }
        public string WordName { get; set; }

        public WordModel() { }

        //overloaded constructor for WordModel
        public WordModel(string t, string d, string e)
        {
            type = t;
            definition = d;
            example = e;
        }
      
    }
}
