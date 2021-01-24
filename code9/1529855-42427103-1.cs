    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace ListviewWCheckboxes
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<someobjects> listItems { get; set; } = new ObservableCollection<someobjects>();
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                listItems.Add(new someobjects("foo"));
                listItems.Add(new someobjects("bar"));
                listItems.Add(new someobjects("blah"));
            }
    
            private void ckbxSelectAll_Checked(object sender, RoutedEventArgs e)
            {
                foreach (someobjects item in listItems)
                {
                    item.is_Selected = (bool)((CheckBox)sender).IsChecked;
                }
            }
    
            public class someobjects : INotifyPropertyChanged
            {
                private string _text;
    
                public string text
                {
                    get { return _text; }
                    set { _text = value; OnPropertyChanged(); }
                }
    
                private bool _is_Selected;
    
                public bool is_Selected
                {
                    get { return _is_Selected; }
                    set { _is_Selected = value; OnPropertyChanged(); }
                }
    
                public someobjects(string t)
                {
                    text = t;
                    is_Selected = false;
                }
    
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
                {
                    var handler = PropertyChanged;
                    if (handler != null)
                        handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
