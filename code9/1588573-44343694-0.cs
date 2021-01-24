        StreamReader txt = new StreamReader(assets.Open("Test12.txt"), Encoding.GetEncoding("Windows-1255"));
		protected override void OnCreate(Bundle bundle)
		{
            // ...
            // First line
            Button1.Text = txt.ReadLine();
		}
        private void Button1_Click(object sender, EventArgs e)
        {
            // other lines
            Button1.Text = txt.ReadLine();
  
        }
	
