    <Button MouseDown="Button_MouseDown" >Click me</Button>
	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if(e.ChangedButton == MouseButton.Right)
        {
        }
		e.Handled = true;
	}
