    public sealed partial class MainPage : Page
    {
        ObservableCollection<Person> _people = new ObservableCollection<Person>();
        int _personCount = 0;
        int _maxPeopleCount = 7;
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = _people;
            Window.Current.SizeChanged += Current_SizeChanged;
        } 
        public void resize()
        { 
            var listpersonheight = listperson.ActualHeight; 
            IEnumerable<ListViewItem> items = FindVisualChildren<ListViewItem>(listperson);
            for (int i = 0; i < items.Count(); i++)
            {
                foreach (ListViewItem item in items)
                {
                    item.Height = (listpersonheight - 10) / _maxPeopleCount;// BorderThickness size need to be minus.
                    item.Width = listperson.ActualWidth - 10; //Width also need resize.
                }
            }
        }
        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            resize();
        }
        private void grdPerson_Loaded(object sender, RoutedEventArgs e)
        {
            resize();
        }
        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        { 
            if (_people.Count == _maxPeopleCount)
            {
                _people.RemoveAt(_people.Count - 1);
            }
            _personCount += 1; 
            _people.Insert(0, new Person($"FirstName {_personCount}", $"LastName {_personCount}")); 
        }
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }  
    }
  
 
