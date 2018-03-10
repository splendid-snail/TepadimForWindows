using System;
using System.Collections.Generic;
using System.Windows;

namespace Tepadim_ForWindows
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private List<string> lineList;
        Random randomiser = new Random();

        public ListWindow()
        {
            InitializeComponent();
   
        }

        private void MakeLine()
        {
            int i = randomiser.Next(0, lineList.Count);
            listBox.Items.Add(lineList[i]);
            listBox.SelectedIndex = listBox.Items.Count - 1;
            listBox.ScrollIntoView(listBox.SelectedItem);
        }

        private void ListWindowFrame_Closed(object sender, EventArgs e)
        {
            this.Owner.Show();
        }

        private void ListWindowFrame_LocationChanged(object sender, EventArgs e)
        {
            this.Owner.Left = this.Left;
            this.Owner.Top = this.Top;            
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                MakeLine();
            }
            listBox.Items.Add("");
        }

        private void MakeListButton_Click(object sender, RoutedEventArgs e)
        {
            lineList = ListManager.MakeList(15); //User can set
            if (lineList[0] != "-1")
            {
                textBlock.Text = "List loaded!";
                loadButton.IsEnabled = true;
                scryButton.IsEnabled = true;
            }
            else
            {
                textBlock.Text = "List failed to load!";
                loadButton.IsEnabled = false;
                scryButton.IsEnabled = false;
            }
        }

        private void ScryButton_Click(object sender, RoutedEventArgs e)
        {
            MakeLine();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
