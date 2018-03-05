using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;


/*
 *Eventually, this class should have:
 *
 * A master list that exists outside functions 
 * MakeList() adds the contents of a txt file (prevent duplicates here or in UI), returns bool
 * FetchList() returns the whole thing
 * ClearList() You get the idea 
 */



namespace Tepadim_ForWindows
{
    public static class ListManager
    {
        public static List<string> MakeList(int phraseLength)
        {
            List<string> lineList = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                //List processing and export code
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                StringBuilder builder = new StringBuilder();
                FileInfo info = new FileInfo(openFileDialog.FileName);

                long fileLength = info.Length;
                long charsRead = 0;
                int sinceLast = 0;

                while(charsRead < fileLength)
                {
                    while (charsRead < fileLength)
                    {
                        //Char reading code: Break 
                        char currentChar = (char)sr.Read();
                        if ((sinceLast > phraseLength) && (currentChar == ' '))
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
                    //Turn the output to a string, tidy it up, 
                    //add it to our list, then reset stuff.
                    string output = builder.ToString();
                    output = output.Trim();
                    output = output.Replace('\r', ' ');
                    output = output.Replace('\n', ' ');
                    output = output.Replace('\t', ' ');
                    lineList.Add(output);
                    //Trace.WriteLine("Adding line: " + output + ", total chars read:" + charsRead); <- a debug thing, we can remove
                    builder.Clear();
                    sinceLast = 0;
                }
                //We now have a list of strings.
                //For now just return the list
                return lineList;
            }
            else
            {
                string msg = "-1";
                lineList.Add(msg);
                return lineList;  
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
