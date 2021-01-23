    MyListView.Items.VectorChanged += ListViewItems_VectorChanged; // in constructor
        
    private void AddRow_Click(object sender, RoutedEventArgs e) {
    
    	card = ....
    	_newRowCard = card;
    	_array.Add(card);
    }
    private void ListViewItems_VectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event) {
    
    	// If new row added, at this point we can safely select and scroll to new item
    	if (_newRowCard != null) {
    		MyListView.SelectedIndex = MyListView.Items.Count - 1; // select row
    		MyListView.ScrollIntoView(MyListView.Items[MyListView.Items.Count - 1]);   // scroll to bottom; this will make sure new row is visible and that DataContextChanged is called
    	}
    }
    
    private void ListViewGrid_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args) {
    
    	// If new row added, at this point the UI is created and we can set focus to text box 
    	if (_newRowCard != null) {
    		Grid grid = (Grid)sender;
    		Card card = (Card)grid.DataContext;  // might be null
    		if (card == _newRowCard) {
    			TextBox textBox = FindControl<TextBox>(grid, typeof(TextBox), "Text1");
    			if (textBox != null) textBox.Focus(FocusState.Programmatic);
    			_newRowCard = null;
    		}
    	}
    }
    
    private void ListViewGrid_GotFocus(object sender, RoutedEventArgs e) {
    	// If user clicks on a control in the row, select entire row
    	MyListView.SelectedItem = (sender as Grid).DataContext;
    }
    
    public static T FindControl<T>(UIElement parent, Type targetType, string ControlName) where T : FrameworkElement {
    
    	if (parent == null) return null;
    	if (parent.GetType() == targetType && ((T)parent).Name == ControlName) return (T)parent;
    
    	int count = VisualTreeHelper.GetChildrenCount(parent);
    	for (int i = 0; i < count; i++) {
    		UIElement child = (UIElement)VisualTreeHelper.GetChild(parent, i);
    		T result = FindControl<T>(child, targetType, ControlName);
    		if (result != null) return result;
    	}
    	return null;
    }
