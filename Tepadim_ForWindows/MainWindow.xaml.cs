﻿using System.Windows;

namespace Tepadim_ForWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TePADiM for Windows: a fortune-telling app in progress.");
        }

        private void listButton_Click(object sender, RoutedEventArgs e)
        {
            ListWindow listWindow = new ListWindow();
            listWindow.Owner = this;
            listWindow.Show();            
            this.Hide();
        }

        private void divineButton_Click(object sender, RoutedEventArgs e)
        {
            DivineWindow divineWindow = new DivineWindow();
            divineWindow.Owner = this;
            divineWindow.Show();
            this.Hide();
        }

        private void candleButton_Click(object sender, RoutedEventArgs e)
        {
            CandleWindow candleWindow = new CandleWindow();
            candleWindow.Owner = this;
            candleWindow.Show();
            this.Hide();
        }
    }
}
