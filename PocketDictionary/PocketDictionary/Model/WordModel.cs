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
<<<<<<< HEAD
        public List<Words> Words { get; set; }
        public static List<Words> myWordList = new List<Words>();
        public String WordName { get; set; }
        
       public WordModel()
        {
            LoadData();
            Words = myWordList;
         
        }

        /*
        public async Task<WordModel> StartAsync()
        {
            await GetData();
            Words = myWordList;
            return this;
        }
        */

        public static async Task LoadData()
        {
            await GetData();
        }
        public static async Task GetData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri("https://owlbot.info/api/v1/dictionary/owl"));
            string result = await response.Content.ReadAsStringAsync();

            
            //var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\somewords.txt");
            //var result = await FileIO.ReadTextAsync(file);
            var wordList = JsonArray.Parse(result);
            CreateWordList(wordList);
=======

        public string type { get; set; }
        public string definition { get; set; }
        public string example { get; set; }
        public string WordName { get; set; }

        public WordModel() { }

        public WordModel(string t, string d, string e)
        {
            type = t;
            definition = d;
            example = e;
>>>>>>> refs/remotes/origin/Restructure
        }
      
    }
}
