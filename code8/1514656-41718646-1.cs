    <Button MouseDoubleClick="Button_MouseDoubleClick" >Click me</Button>
	private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		if(e.ChangedButton == MouseButton.Right)
        {
        }
		e.Handled = true;
	}
