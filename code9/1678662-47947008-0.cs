        private int i = 0; // or in hidden field
        private void next_Click(object sender, EventArgs e)
        {
            string[] baca;
            baca = System.IO.File.ReadAllLines(@path.Text);
            nama.Text = baca[i];
            npm.Text = baca[i+1];
            alamat.Text = baca[i+2];
        }
