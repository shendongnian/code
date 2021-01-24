    private void Form1_Load(object sender, System.EventArgs e)
    {
    	if (CheckInternet) // change to upper case (convention for methods)
        {
             imagebox1.Image = Image.FromFile(ImagePathForConnectedSate);
        }
        else
        {
             imagebox1.Image = Image.FromFile(ImagePathForDisconnectedSate);
        }
    }
