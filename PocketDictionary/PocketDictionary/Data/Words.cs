using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;
using Model;

namespace Data
{
    public class Words
    {
        //private static List<WordModel> wmodel;

        //public static List<WordModel> myWordList = new List<WordModel>();

        public static WordModel myWord;
        
        public static async Task<WordModel> GetDefinitionAsync()
        {
            await Task.Delay(3000);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(new Uri("https://owlbot.info/api/v1/dictionary/dictionary"));
            string result = await response.Content.ReadAsStringAsync();

            //var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\somewords.txt");
            //var result = await FileIO.ReadTextAsync(file);
            var wordList = JsonArray.Parse(result);

            foreach (var item in wordList)
            {
                var oneWord = item.GetObject();
               WordModel aWord = new WordModel();

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
                } // end foreach(var key)
                //myWordList.Add(aWord);
                myWord = aWord;
            } // end foreach (var item )

        
            return myWord;
        }
    }

}
