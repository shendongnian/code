    private void button1_Click(object sender, EventArgs e)
        {
            string filename = textBox1.Text + ".pdf";
            string path = @"c:\temp\";
            string pathfilename = string.Concat(path,filename);
            System.Diagnostics.Process.Start(pathfilename);
        }
