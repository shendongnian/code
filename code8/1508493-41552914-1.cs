    private void ReadFile_Click(object sender, EventArgs e)
    {
        try
        {
            using (StreamReader file = new StreamReader("C:\\test.txt"))
            {
                var temp = file.ReadToEnd();
                // temp = temp.Replace("\r\n","\n");  You may or may not have to do something like this 
                textBox1.Text = temp;
            }
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "File not found");
            return;
        }
