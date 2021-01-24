    int firstIndex = 0;
    var baca = System.IO.File.ReadAllLines(@path.Text).ToList();
    private void next_Click(object sender, EventArgs e)
    {
        firstIndex++;  
        nama.Text = baca[firstIndex];
        npm.Text = baca[firstIndex + 1];
        alamat.Text = baca[firstIndex + 2];
    }
