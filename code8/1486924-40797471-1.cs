	private void ButtonAll_Click(object sender, MouseEventArgs e)
	{
		ResetAllButtonImage();
		Button b = sender as Button;
		if(b.Text == "A") // or tag or Name Something to find
		{
			b.Image=(Image)(Properties.Resources.MouseClickThietLap);
		}
		else if(b.Text == "B")
		{
			b.Image=(Image)(Properties.Resources.MouseClickKhachHang);
		}
		else
		{
			b.Image=(Image)(Properties.Resources.MouseClickDoanhSo);
		}
	}
 
