using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tepadim_ForWindows
{
    public static class MarkovMaker
    {
        public static IDictionary<string, string[]> ReadFile()
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
                return dict;
            }
            else
            {
                return dict;
            }
        }
    }
}
