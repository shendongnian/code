	public void Form1
	{
		public Form1(ViewModel viewModel)
		{
			UserControl1.DataBindings.Add("TextBoxTextProperty", viewModel, "TextBoxText");
			UserControl3.DataBindings.Add("MaterialCheckBoxCheckedProperty", viewModel, "CheckBoxChecked");
		}
	}
	
