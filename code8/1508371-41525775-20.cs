	void TextBox_LostFocus( object sender, RoutedEventArgs e )
	{
		var tb = (TextBox)sender;
		var pm = (MyViewModel)DataContext;
		tb.GetBindingExpression( TextBox.TextProperty ).UpdateSource();
		pm.OnPropertyChanged( "Text" );
	}
