using System;
using System.Windows;

namespace Tepadim_ForWindows
{
    /// <summary>
    /// Interaction logic for DivineWindow.xaml
    /// </summary>
    public partial class DivineWindow : Window
    {
        public DivineWindow()
        {
            InitializeComponent();
            label.Content = MarkovMaker.Status;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        private void ListWindowFrame_LocationChanged(object sender, EventArgs e)
        {
            Owner.Left = this.Left;
            Owner.Top = this.Top;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "Loading...";
            MarkovMaker.ReadFile();
            label.Content = MarkovMaker.Status;
        }

        private void divineButton_Click(object sender, RoutedEventArgs e)
        {
            int lengthChoice= 10;
            if (comboBox.SelectedIndex == 0)
            {
                lengthChoice = 10;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                lengthChoice = 40;
            }
            else
            {
                lengthChoice = 100;
            }

            if (MarkovMaker.DictionaryMade)
            {
                textBox.Text = MarkovMaker.Divine(lengthChoice);
            }
            else
            {
                label.Content = MarkovMaker.Status;
            }
        }
    }
}
