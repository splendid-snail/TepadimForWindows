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
            textBox.Text = MarkovMaker.Divine(20);
        }
    }
}
