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
    /// Interaction logic for CandleWindow.xaml
    /// </summary>
    public partial class CandleWindow : Window
    {
        public CandleWindow()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }
    }
}
