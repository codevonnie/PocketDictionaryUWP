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
        public List<Words> Words { get; set; }
        public static List<Words> myWordList = new List<Words>();
        public String WordName { get; set; }

        public WordModel()
        {
            Update();
        }

        public static async Task<List<Words>> Update()
        {
            return myWordList = (await DataService.GetDefinition());

        }
    }
}
