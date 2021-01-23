	private void TextBox_TextChanged( object sender, TextChangedEventArgs e )
	{
		var tb = (TextBox)sender;
		var pm = (MyViewModel)DataContext;
		tb.GetBindingExpression( TextBox.TextProperty ).UpdateSource();
		if ( tb.Text != pm.Text )
			tb.Text = pm.Text; //correct two-way binding's target
	}
