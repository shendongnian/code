    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Collections.ObjectModel;
    namespace CustomListBox
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ViewModel.Things = new ObservableCollection<ThingViewModel>(
                    Directory.GetFiles("c:\\").Select(fn => new ThingViewModel { Name = fn }));
                ViewModel.Stuff = new ObservableCollection<Object>(
                    Enumerable.Range(1, 10).Select(n => new { Blah = Math.Log(n), Foobar = n }));
                ViewModel.Stuff.Insert(0, new { Blah = "Different type, same name", Foobar = "LOL" });
            }
            public MainViewModel ViewModel => (MainViewModel)DataContext;
        }
    }
