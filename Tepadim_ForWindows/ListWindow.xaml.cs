using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            int i = randomiser.Next(0, lineList.Count);
            listBox.Items.Add(lineList[i]);
            listBox.SelectedIndex = listBox.Items.Count - 1;
            listBox.ScrollIntoView(listBox.SelectedItem);
        }

        private void makeListButton_Click(object sender, RoutedEventArgs e)
        {
            lineList = ListManager.MakeList(15); //User can set
            textBlock.Text = "List loaded!";
            loadButton.IsEnabled = true;
        }
    }
}
