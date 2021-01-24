	private void btnCalculatE_Click(object sender, EventArgs e)
	{
		double Length;
		double Width;
		Length = Convert.ToDouble(txtLength.Text);
		Width = Convert.ToDouble(txtWidth.Text);
        txtArea.Text = Convert.ToString(Length * Width);
        txtPerimeter.Text = Convert.ToString(2 * (Length + Width));
		//The following has nothing to do with calculating the result.
        //You may leave it if you intend to set focus to the *Length* textbox after calculating.
		txtLength.Focus();
	}
