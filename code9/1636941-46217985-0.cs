	public Form1()
	{
		InitializeComponent();
		roBox.ReadOnlyChanged += roBox_ReadOnlyChanged;
	}
	private void roBox_ReadOnlyChanged(object sender, EventArgs e)
	{
		throw new Exception("who did this");
	}
