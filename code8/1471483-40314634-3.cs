    public partial class DynamicSourceComboBox : UserControl
    {
        public DynamicSourceComboBox()
        {
            InitializeComponent();
        }
        public object SelectedValue
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(object), typeof(DynamicSourceComboBox), new PropertyMetadata(null));
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            ComboBox.ItemsSourceProperty.AddOwner(typeof(DynamicSourceComboBox));
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }
        public static readonly DependencyProperty DisplayMemberPathProperty =
            ComboBox.DisplayMemberPathProperty.AddOwner(typeof(DynamicSourceComboBox));
        private void selected_Click(object sender, RoutedEventArgs e)
        {
            selected.Visibility = Visibility.Hidden;
            selections.Visibility = Visibility.Visible;
            selections.IsDropDownOpen = true;
        }
        private void selections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selections.Visibility = Visibility.Collapsed;
            selected.Visibility = Visibility.Visible;
            selections.IsDropDownOpen = false;
            if (e.AddedItems.Count == 1)
            {
                var item = e.AddedItems[0];
                Type itemType = item.GetType();
                var itemTypeProps = itemType.GetProperties();
                var realValue = (from prop in itemTypeProps
                                where prop.Name == DisplayMemberPath
                                select prop.GetValue(selections.SelectedValue)).First();
                SelectedValue = realValue;
            }  
        }
        private void selections_MouseLeave(object sender, MouseEventArgs e)
        {
            selections.Visibility = Visibility.Collapsed;
            selected.Visibility = Visibility.Visible;
            selections.IsDropDownOpen = false;
        }
    }
