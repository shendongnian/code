using System.Collections.ObjectModel;
    private ObservableCollection<string> listitem;
        public Window5()
        {
            InitializeComponent();
            listitem = new ObservableCollection<string> { "ListItem 1", "ListItem 2" };
            Listbox1.ItemsSource = listitem;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            listitem.Insert(listitem.Count, textbox1.Text);
            textbox1.Clear();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            int index = Listbox1.SelectedIndex;
            listitem.RemoveAt(Listbox1.SelectedIndex);
        }
