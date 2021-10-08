using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

Dictionary<string, string> translate = new Dictionary<string, string>();


List<string> lines = File.ReadAllLines("dict.txt").ToList();  //reads all lines of dict.txt, converts it to a list and is assigned to List<string> lines

foreach (string line in lines) //This will loop through all the lines in dict.txt (made into a list via .ToList)
{
    List<string> words = line.Split("|").ToList();  //a line of text which is written in the format "english word|swedish word"
    string swe = words[1];                          // which is split and converted to a list called parts
    string eng = words[0]; 
    //Now the line has been split between "|", the first string [0] is assigned to eng, with the second string [1] assigned to swe


    translate.Add(eng, swe); //finally, these broken down lines from dict.txt are added into the Dictionary<> translate on line 6
}
//^ process is repeated until the foreach loop has gone through all lines in dict.txt

while (true)
{
    Console.WriteLine("Type in an English word/phrase to translate to Swedish (press Enter to leave): ");
    string word = Console.ReadLine().ToLower(); //.ToLower is to ensure whether the user capitalises the English word, the dictionary will still function
    if (word == "") break; //breaks the While loop
    if (translate.ContainsKey(word))  //uses the user entered word to search through the keys (first string in each line of the dictionary) for a match
    {
        Console.Write("\n" + word + " in Swedish is " + translate[word] + "\n\n");  //If a matching key is found, will bring up the second string; the swedish version
    }
    else
    {
        Console.WriteLine("\nThe word/phrase " + word + ", could not be found.\n\nWould you like to add it to the dictionary? (yes/no)");
        string choice = Console.ReadLine().ToLower();  //Allows user to choose to enter the words if the dictionary doesn't contain it

        switch (choice)
        {  
            case "yes": 
                ////Console.WriteLine("\nWhat's the English word or phrase you want to add? "); 
                //string engWord = Console.ReadLine().ToLower();

                Console.WriteLine("\nWhat is the Swedish equivalent? ");
                string sweWord = Console.ReadLine();

                translate.Add(word, sweWord); //both strings are entered into the translate dictionary

                File.AppendAllText("dict.txt", "\n" + word + "|" + sweWord); break;  //this also saves the entry into the dict.txt so it's not wiped after the program finishes!

            case "no":
                break;

            default: Console.WriteLine("I do not understand, please try again\n"); break;
        }
    }
   

}
Console.WriteLine("\n\t\t\t\tThanks for using the dictionary, hejdå!");
