using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Tepadim_ForWindows
{
    public static class ListManager
    {

        public static string MakeList()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                //List processing and export code
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                StringBuilder builder = new StringBuilder();
                FileInfo info = new FileInfo(openFileDialog.FileName);
                List<string> lineList = new List<string>();

                long fileLength = info.Length;
                long charsRead = 0;
                int sinceLast = 0;

                while(charsRead < fileLength)
                {
                    while (charsRead < fileLength)
                    {
                        //Char reading code: Break 
                        char currentChar = (char)sr.Read();
                        if ((sinceLast > 35) && (currentChar == ' '))
                        {
                            break;
                        }
                        else
                        {
                            builder.Append(currentChar);
                            charsRead++;
                            sinceLast++;
                        }
                    }
                    //Turn the output to a string, add it to our list,
                    //then reset stuff. Any further string processing can happen here: trimming whitespace, empty strings, newlines etc
                    string output = builder.ToString();   
                    lineList.Add(output);
                    //Trace.WriteLine("Adding line: " + output + ", total chars read:" + charsRead); <- a debug thing, we can remove
                    builder.Clear();
                    sinceLast = 0;
                }
                //We now have a list of strings. Now to turn them into a new .tpd file... eventually
                //For now just return a random string
                Random randomiser = new Random();
                int i = randomiser.Next(0, lineList.Count);
                return lineList[i];                               
            }
            else
            {
                return "Void!";
            }
        }

        public static string ReturnLists()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return "Void!";
            }
        }
    }
}
