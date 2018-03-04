﻿using System;
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
using Microsoft.Win32;

namespace Tepadim_ForWindows
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path = ListManager.ReturnLists();
            textBlock.Text = path;
        }

        private void makeListButton_Click(object sender, RoutedEventArgs e)
        {
            string tester = ListManager.MakeList();
            textBox.Text = tester;
        }
    }
}