    <DataTemplate x:Key="myTemplateSplitPayeeEdit">
        <local:FilteringComboBox Style="{StaticResource GridComboStyle}"
                  SelectedItem="{Binding PayeeOrTransferCaption, Mode=TwoWay}"
                  ItemsSource="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type views:TransactionsView}}, Path=PayeesAndTransferNames}" 
                  PreviewLostKeyboardFocus="ComboBoxForPayee_PreviewLostKeyboardFocus"  
                  FilterChanged="ComboBoxForPayee_FilterChanged"
                 >
            <ComboBox.ItemsPanel>
                <ItemsPanelTemplate>
                    <VirtualizingStackPanel />
                </ItemsPanelTemplate>
            </ComboBox.ItemsPanel>
        </local:FilteringComboBox>
    </DataTemplate>
        private void ComboBoxForPayee_FilterChanged(object sender, RoutedEventArgs e)
        {
            FilteringComboBox combo = sender as FilteringComboBox;
            combo.FilterPredicate = new Predicate<object>((o) => { return o.ToString().IndexOf(combo.Filter, StringComparison.OrdinalIgnoreCase) >= 0; });
        }
    public class FilteringComboBox : ComboBox
    {
        public static RoutedEvent FilterChangedEvent = EventManager.RegisterRoutedEvent("FilterChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FilteringComboBox));
        public event RoutedEventHandler FilterChanged;
        ListCollectionView view;
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            Filter = null;
            Items.Filter = null;
            this.view = newValue as ListCollectionView;
            base.OnItemsSourceChanged(oldValue, newValue);
        }
        public Predicate<object> FilterPredicate
        {
            get { return view.Filter; }
            set { view.Filter = value; }
        }
        public override void OnApplyTemplate()
        {            
            base.OnApplyTemplate();
            TextBox edit = this.Template.FindName("PART_EditableTextBox", this) as TextBox;
            if (edit != null)
            {
                edit.KeyUp += new System.Windows.Input.KeyEventHandler(OnEditKeyUp);
            }
        }
        void OnEditKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox box = (TextBox)sender;
            string filter = box.Text;
            if (string.IsNullOrEmpty(filter))
            {
                Items.Filter = null;
            }
            else if (box.SelectionLength < filter.Length)
            {
                if (box.SelectionStart >= 0)
                {
                    filter = filter.Substring(0, box.SelectionStart);
                }
                SetFilter(filter);
            }
        }
        public string Filter { 
            get; set; 
        }
        void SetFilter(string text)
        {
            Filter = text;
            var e = new RoutedEventArgs(FilterChangedEvent);
            if (FilterChanged != null)
            {
                FilterChanged(this, e);
            }
            RaiseEvent(e);
        }
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
        }
    }
