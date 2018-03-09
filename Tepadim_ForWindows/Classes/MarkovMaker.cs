using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tepadim_ForWindows
{
    public static class MarkovMaker
    {
        public static string Status = "Ready";
        public static bool DictionaryMade = false;
        private static IDictionary<string, List<string>> Dictionary = new Dictionary<string, List<string>>();        
        private static Random randomiser = new Random();
        
        public static void ReadFile()
        {
            IDictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo info = new FileInfo(openFileDialog.FileName);
                string wholeText = File.ReadAllText(openFileDialog.FileName);
                //Do you wish to see regex magic? Very well...
                //Just replaces multiple newlines with a single newline for now
                string pattern = @"\n+";
                string replacement = "\n";
                Regex regex = new Regex(pattern);
                string trimmedText = regex.Replace(wholeText, replacement);

                string[] wordListArray = trimmedText.Split(' ');
                int wordListLength = wordListArray.Length;  

                for (int i = 0; i < wordListLength - 2; i++)
                {
                    string wordOne = wordListArray[i];
                    string wordTwo = wordListArray[i + 1];
                    string wordThree = wordListArray[i + 2];
                    string thisKey = wordOne + " " + wordTwo;
                    
                    if (dict.ContainsKey(thisKey))
                    {  
                        List<string> existingValue = dict[thisKey];                 
                        existingValue.Add(wordThree);                        
                        dict[thisKey] = existingValue;    
                    }
                    else
                    {
                        List<string> thisValue = new List<string> { wordThree };
                        dict.Add(thisKey, thisValue);
                    }
                }
                Status = "Dictionary from " + openFileDialog.SafeFileName + " created";
                Dictionary = dict;
                DictionaryMade = true;
                return;
            }
        }

        public static string Divine(int length)
        {            
            string output = "";

            if (DictionaryMade)
            {
                //Choose an initial dictionary value
                int thisIndex = randomiser.Next(0, Dictionary.Count);//Random index
                string thisKey = Dictionary.ElementAt(thisIndex).Key;//Get the key (two-word string)
                List<string> thisValueArray = Dictionary.ElementAt(thisIndex).Value;//Get the value (array of one-word strings)
                string thisValue = thisValueArray[randomiser.Next(0, thisValueArray.Count())];//Choose a random string from the array
                string[] splitKey = thisKey.Split(' ');//Split the key into single words 
                output += splitKey[0] + " ";//Add the first word to the output 

                string nextKey = splitKey[1] + " " + thisValue;//Make the next key
                int count = 0;
                string oldWord = "";
                string evenOlderWord = "";
                string newWordPicked = "";

                while (count < length)
                {
                    //Check we have it, if not get another random one:
                    if (Dictionary.ContainsKey(nextKey))
                    {
                        thisKey = nextKey;    
                    }
                    else
                    {
                        thisIndex = randomiser.Next(0, Dictionary.Count);
                        thisKey = Dictionary.ElementAt(thisIndex).Key;
                    }

                    //Get to work
                    thisValueArray = Dictionary.ElementAt(thisIndex).Value;
                    thisValue = thisValueArray[randomiser.Next(0, thisValueArray.Count())];
                    splitKey = thisKey.Split(' ');

                    evenOlderWord = oldWord;
                    oldWord = newWordPicked;
                    newWordPicked = splitKey[0];  

                    output += newWordPicked + " ";

                    //Deal with endlessly repeating words... 
                    if (newWordPicked == oldWord && oldWord == evenOlderWord)
                    {
                        Trace.WriteLine("Fixing repetition");
                        thisIndex = randomiser.Next(0, Dictionary.Count);
                        nextKey = Dictionary.ElementAt(thisIndex).Key; 
                    }
                    else
                    {
                        nextKey = splitKey[1] + " " + thisValue;
                    }
                                        
                    count++;
                }
                Trace.WriteLine("***NEW OUTPUT***");
                Trace.WriteLine(output);
                return output;
            }
            else
            {
                Trace.WriteLine("Dictionary not made!");
                return "Dictionary not made!";
            }
        }
    }
}
