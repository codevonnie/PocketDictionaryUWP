# Pocket Dictionary UWP

This is a project for 4th Year Mobile Applications module as part of a Bsc in Software Development.

The project is a dictionary app for Universal Windows Platform (UWP) which uses the Model-View-ViewModel (MVVM) pattern of development.  

To use the app, the user should open the solution file in Visual Studio 15.  Once the app is deployed, the user can input a word into the input box and click the search button to search for its definition.  This project requires access to the internet as the definition is retrieved from an online [API](http://www.programmableweb.com/api/owlbot-dictionary) 

An example query would be the input of the word **"dictionary"**.

The returned json value would be: 
```
[
    {
        "type": "noun",
        "defenition": "a book or electronic resource that lists the words of a language (typically in alphabetical order) and gives their meaning, or gives the equivalent words in a different language, often also providing information about pronunciation, origin, and usage.",
        "example": "\"I'll look up 'love' in the dictionary\""
    }
]
```
