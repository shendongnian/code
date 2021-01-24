    public class ListBoxSelectedItemsAttachedProperty
    {
        #region SelectedItems
        public static readonly DependencyProperty SelectedItemsProperty; 
            
        static ListBoxSelectedItemsAttachedProperty()
        {
            FrameworkPropertyMetadata MetaData = new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                                                 , new PropertyChangedCallback(OnSelectedItemsChanged));
            
            SelectedItemsProperty =  DependencyProperty.RegisterAttached("SelectedItems", typeof(IList),
                                     typeof(ListBoxSelectedItemsAttachedProperty),
                                     MetaData);
        }
   
        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedItemsProperty);
        }
        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }
        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox listBox = (ListBox)d;
            listBox.SelectionChanged +=  listBox_SelectionChanged;
            listBox.Unloaded += listBox_Unloaded;
        }
        private static void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = (ListBox)sender;
            IEnumerable listBoxSelectedItems = list.SelectedItems;
            IList ModelSelectedItems = GetSelectedItems(list);
            ModelSelectedItems.Clear();
            if (list.SelectedItems != null)
            {
                foreach (var item in list.SelectedItems)
                    ModelSelectedItems.Add(item);
            }
            SetSelectedItems(list, ModelSelectedItems);
        }
        private static void listBox_Unloaded(object sender, RoutedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            listBox.SelectionChanged -= listBox_SelectionChanged;
            listBox.Unloaded -= listBox_Unloaded;
        }
        #endregion
    }
