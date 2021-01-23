    public class CustomListBox : ListBox
    {
        public CustomListBox()
        {
            this.SelectionChanged += CustomListBox_SelectionChanged;
        }
        void CustomListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedItemsList = this.SelectedItems;
        }
        #region SelectedItemsList
        public IList SelectedItemsList
        {
            get { return (IList)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemsListProperty =
                DependencyProperty.Register("SelectedItemsList", typeof(IList), typeof(CustomListBox), new PropertyMetadata(null));
        #endregion
    }
