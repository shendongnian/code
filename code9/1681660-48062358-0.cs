    private void btnLoad_Click(object sender, EventArgs e)
    {
        btnLoad.Enabled = false;
        // spilt the text on LF and/or CR values
        // this gives an array of strings
        string[] urls = textBox1.Text
            .Split(
                new char[] { '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries
            );
        // hand the urls to the background worker
        bgwLoader.RunWorkerAsync(urls);
    }
