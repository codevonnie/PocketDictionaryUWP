//Word class gets data from api to make WordModel

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
        //instance of WordModel for response
        public static WordModel myWord;
        
        //method called from viewmodel to get definition from api - takes in string inputted by user from GUI
        public static async Task<WordModel> GetDefinitionAsync(String input)
        {
            myWord = null;
            //constant address
            var address = "https://owlbot.info/api/v1/dictionary/";

            //creates Http Client connection
            HttpClient client = new HttpClient();

            //request link is build from 
            Uri requestUri = new Uri(address + input);
            //save client connection attempts to connect to api, response will be saved to response
            HttpResponseMessage response = await client.GetAsync(requestUri);

            //async call to serialize response to a string
            string result = await response.Content.ReadAsStringAsync();
            
            //if no result, return
            if (result == null)
            {
                return myWord;
            }
            //convert result to a Json Array
            var wordList = JsonArray.Parse(result);

            //loop through each entry in array
            foreach (var item in wordList)
            {
               var oneWord = item.GetObject();
                //create instance of WordModel
                WordModel aWord = new WordModel();

                //loop through list of keys and assign each to the correct WordModel attribute
                foreach (var key in oneWord.Keys)
                {
                    IJsonValue value;
                    if (!oneWord.TryGetValue(key, out value))
                        continue;

                    //try/catch added because not all responses have all attributes so if empty, mark attribute as blank
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
                
                //after looping through response save created WordModel to static WordModel
                myWord = aWord;
            } // end foreach (var item )

            //return WordModel to caller
            return myWord;
        }
    }

}
