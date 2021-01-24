    private void next_Click(object sender, EventArgs e)
    {
        var baca = System.IO.File.ReadAllLines(@path.Text).ToList();
        int firstIndex = 1 + baca.FindIndex(nama.Text);    
        nama.Text = baca[firstIndex];
        npm.Text = baca[firstIndex + 1];
        alamat.Text = baca[firstIndex + 2];
    }
