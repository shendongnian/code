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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace Player
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ViewModel = new MainViewModel();
                ViewModel.Player = new PlayerViewModel() { Name = "Ivan the Terrible" };
                ViewModel.AddGreeting();
            }
            //  Just here as a convenience, and to make sure we don't give the DataContext
            //  the wrong kind of viewmodel. 
            public MainViewModel ViewModel
            {
                set { DataContext = value; }
                get { return DataContext as MainViewModel; }
            }
        }
    }
