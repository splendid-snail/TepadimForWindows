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
            Left = Owner.Left;
            Top = Owner.Top;
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            MarkovMaker.ReadFile();
        }
    }
}
