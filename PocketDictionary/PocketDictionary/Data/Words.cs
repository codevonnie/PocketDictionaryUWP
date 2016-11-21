using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;

namespace Data
{
    public class Words
    {
        public string type { get; set; }
        public string definition { get; set; }
        public string example { get; set; }
    }

    public class DataService
    {
        //public static String Name = "Fake Data Service.";
        public static List<Words> myWordList = new List<Words>();

        public static async Task<List<Words>> GetDefinition()
        {
            //HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync(new Uri("https://owlbot.info/api/v1/dictionary/owl"));
            //string result = await response.Content.ReadAsStringAsync();


            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\somewords.txt");
            var result = await FileIO.ReadTextAsync(file);
            var wordList = JsonArray.Parse(result);

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
                } // end foreach(var key)
                myWordList.Add(aWord);
            } // end foreach (var item )

            return myWordList;

        }

        public static void Write(Words words)
        {
            //Debug.WriteLine("INSERT person with name " + person.Name);
        }

        
    }

}
