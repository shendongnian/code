	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Task.Run(()=>
			{
				Method();
			}
		);
	}
	public void Method() {
		//do something
		a.progBarValue += 10;
		//do something
		a.progBarValue += 10;
		//do something
		MessageBox.Show("Finished");
		a.progBarValue = 0;
	}
