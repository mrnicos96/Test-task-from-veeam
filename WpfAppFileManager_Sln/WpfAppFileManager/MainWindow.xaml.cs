using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfAppFileManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }
    }
}
