    private void yourTextBox_TextChanged(object sender, EventArgs e)
		{
			if (System.IO.File.Exists(yourTextBox.Text))
				pictureBox.Image = Image.FromFile(yourTextBox.Text);
		}
