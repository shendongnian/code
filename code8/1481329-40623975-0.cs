    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Threading;
    
    namespace ListBoxTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        /// 
    
        public class OasisInstance : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            ObservableCollection<string> _items = new ObservableCollection<string>();
            public ObservableCollection<string> ShowList
            {
                get { return _items; }
                set {
                    if (_items != value)
                    {
                        _items = value; NotifyPropertyChanged();
                    }
                }
            }
    
            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        public class MainApplication
        {
            public OasisInstance OasisInst  = new OasisInstance();
        }
    
        public partial class MainWindow : Window
        {
            MainApplication mainApp = new MainApplication();
            DispatcherTimer timer = new DispatcherTimer();
    
            public MainWindow()
            {
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += (s, e) => { mainApp.OasisInst.ShowList.Add(DateTime.Now.ToString()); };
                timer.Start();
    
                InitializeComponent();
    
                lbxShows.ItemsSource = mainApp.OasisInst.ShowList;
            }
        }
    }
