    private void Form1_Load(object sender, System.EventArgs e)
    {
        if (checkinternet())
        {
             imagebox1.Image = Image.FromFile("p://ath/to/online/image.jpg");
        }
        else
        {
             imagebox1.Image = Image.FromFile("p://ath/to/offline/image.jpg");
        }
    }
