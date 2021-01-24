    class CustomListBox : ListBox
    {
        public CustomListBox()
        {
            this.SelectionChanged += CustomListBox_SelectionChanged;
        }
        void CustomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<MyItem> tempList = new ObservableCollection<MyItem>();
            foreach (MyItem i in this.SelectedItems)
            {
                tempList.Add(i);
            }
            this.SelectedItemsList = tempList;
        }
        #region SelectedItemsList
        public ObservableCollection<MyItem> SelectedItemsList
        {
            get { return (ObservableCollection<MyItem>)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemsListProperty =
            DependencyProperty.Register("SelectedItemsList", typeof(ObservableCollection<MyItem>), typeof(CustomListBox),
            new PropertyMetadata(new ObservableCollection<MyItem>(), new PropertyChangedCallback(OnSelectionChanged)));
        public static void OnSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomListBox clb = d as CustomListBox;
            var selectedItems = e.NewValue as ObservableCollection<MyItem>;
            if (selectedItems != null)
            {
                clb.SetSelectedItems(selectedItems);
            }
        }
        #endregion
    }
