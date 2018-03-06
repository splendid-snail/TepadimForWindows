using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Tepadim_ForWindows
{
    public static class MarkovMaker
    {
        public static string Status = "Dictionary not made!";
        private static IDictionary<string, string[]> Dictionary = new Dictionary<string, string[]>();
        private static bool DictionaryMade = false;
        private static Random randomiser = new Random();
        
        public static bool ReadFile()
        {
            List<string> wordList = new List<string>();
            //The below should probably take a list rather than an array from the start,
            //rather than messing around converting later??
            IDictionary<string, string[]> dict = new Dictionary<string, string[]>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo info = new FileInfo(openFileDialog.FileName);
                //We should probably do our list-tidying below. Now might be a good time to switch
                //this array to a list throughout the function...
                string[] wordListArray = File.ReadAllText(openFileDialog.FileName).Split(' ');
                int wordListLength = wordListArray.Length;  

                for (int i = 0; i < wordListLength - 2; i++)
                {
                    string wordOne = wordListArray[i];
                    string wordTwo = wordListArray[i + 1];
                    string wordThree = wordListArray[i + 2];
                    string thisKey = wordOne + " " + wordTwo;
                    
                    if (dict.ContainsKey(thisKey))
                    {
                        Trace.WriteLine("Key " + thisKey + " already found!");
                        string[] existingValue = dict[thisKey];
                        //We now need to check if existingValue has wordThree in it... anywhere
                        //If not, add wordThree
                        //Then set dict[thisKey] to the modified existingValue
                        if (!existingValue.Contains(wordThree))
                        {
                            Trace.WriteLine("Adding new word to existing value");
                            List<string> existingList = existingValue.ToList();
                            existingList.Add(wordThree);
                            existingValue = existingList.ToArray();
                            dict[thisKey] = existingValue;                            
                        }
                        Trace.WriteLine("Same as current Value: " + existingValue[0]);
                    }
                    else
                    {
                        string[] thisValue = new string[] { wordThree };
                        dict.Add(thisKey, thisValue);
                    }
                }
                Trace.WriteLine(dict.Count);
                Status = "Dictionary from " + openFileDialog.SafeFileName + " created";
                Dictionary = dict;
                DictionaryMade = true;
                return true;
            }
            else
            {
                return false;
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
                string[] thisValueArray = Dictionary.ElementAt(thisIndex).Value;//Get the value (array of one-word strings)
                string thisValue = thisValueArray[randomiser.Next(0, thisValueArray.Count())];//Choose a random string from the array
                string[] splitKey = thisKey.Split(' ');//Split the key into single words 
                output += splitKey[0] + " ";//Add the first word to the output 

                string nextKey = splitKey[1] + " " + thisValue;//Make the next key
                int count = 0;
                bool done = false;

                while (!done)
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
                    output += splitKey[0] + " ";
                    nextKey = splitKey[1] + " " + thisValue;
                    count++;
                    if (count == length)
                    {
                        done = true;
                        Trace.WriteLine(output);
                        return output;
                    }
                }
            }
            else
            {
                Trace.WriteLine("Dictionary not made!");
                return "Dictionary not made!";
            }
            return "Dictionary not made!";
        }
    }
}
