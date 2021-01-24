	class MainForm : Form
	{
		public MainForm()
		{
			var button = new Button();
			button.Click += button_pressed;
			button.Text = "Ask number";		
			this.Controls.Add(button);		
		}
		
		void button_pressed(object sender, EventArgs e)
		{
			var child = new SubForm();
			var result = child.ShowDialog();
	
			if (result == DialogResult.OK)
			{
				MessageBox.Show($"Entered number is {child.SelectedNumber}");
			}
		}
	}
