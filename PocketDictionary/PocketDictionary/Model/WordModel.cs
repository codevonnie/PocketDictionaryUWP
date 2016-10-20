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
            LoadData();
            Words = myWordList;
        }

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
        }

        private static void CreateWordList(JsonArray wordList)
        {
            foreach (var item in wordList)
            {
                var oneWord = item.GetObject();
                Words aWord = new Words();

                foreach (var key in oneWord.Keys)
                {
                    IJsonValue value;
                    if (!oneWord.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        case "type":
                            aWord.type = value.GetString();
                            break;
                        case "defenition":
                            aWord.definition = value.GetString();
                            break;
                        case "example":
                            aWord.example = value.GetString();
                            break;
                        
                    } // end switch
                } // end foreach(var key in oneDog.Keys )
                myWordList.Add(aWord);
            } // end foreach (var item in jDogList)
        }

    }
}
