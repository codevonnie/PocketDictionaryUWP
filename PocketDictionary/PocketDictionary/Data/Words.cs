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

        public static WordModel myWord;
        
        public static async Task<WordModel> GetDefinitionAsync(String input)
        {
            await Task.Delay(3000);
            myWord = null;

            HttpClient client = new HttpClient();
            //HttpResponseMessage response = await client.GetAsync(new Uri(input));
            Uri requestUri = new Uri("https://owlbot.info/api/v1/dictionary/" + input);
            HttpResponseMessage response = await client.GetAsync(requestUri);

            string result = await response.Content.ReadAsStringAsync();
            if (result == null)
            {
                 
            }
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
                            try
                            {
                                aWord.type = "Type: " + value.GetString();
                            }
                            catch
                            {
                                aWord.type = "";
                            }
                            break;
                        case "defenition":
                            try
                            {
                                aWord.definition = "Definition: " + value.GetString();
                            }
                            catch
                            {
                                aWord.definition = "";
                            }
                            break;
                        case "example":
                            try
                            {
                                aWord.example = "Example: " + value.GetString();
                            }
                            catch
                            {
                                aWord.example = "";
                            }
                                
                            break;

                    } // end switch
                } // end foreach(var key)
                //myWordList.Add(aWord);
                //aWord.WordName = input;
                myWord = aWord;
            } // end foreach (var item )

            return myWord;
        }
    }

}
