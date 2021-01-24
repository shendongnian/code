	class SubForm : Form
	{
		public int SelectedNumber { get; set;}
	
		public SubForm()
		{
			var button = new Button();		
			var textBox = new TextBox();
	
			button.Click += (s, e) => {
				int i;
				if (int.TryParse(textBox.Text, out i))
				{
					this.SelectedNumber = i;
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
				else
				{
					MessageBox.Show("pls, enter number", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				
			};	
			
			textBox.SetBounds(0, 0, 100, 20);
			button.SetBounds(100, 0, 30, 20);
			
			button.Text = "OK";		
			this.Controls.Add(textBox);
			this.Controls.Add(button);
		}	
	}
	
