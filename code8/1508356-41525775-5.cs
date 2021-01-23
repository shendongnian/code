	void ComboBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
	{
		var cb = (ComboBox)sender;
		var pm = (MyViewModel)DataContext;
		cb.GetBindingExpression( ComboBox.SelectedItemProperty ).UpdateSource();
		if ( (string)cb.SelectedItem != pm.Text )
			cb.SelectedItem = pm.Text; //correct two-way binding's target
	}
