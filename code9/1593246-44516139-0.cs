    private void Button1_Click(object sender, EventArgs e)
    {
        //if open successfully, then apply streamReader to it
        if (openFile.ShowDialog() == DialogResult.OK)
        {
            List<string> info = new List<string>();
            StreamReader sr = new StreamReader(openFile.FileName);
            //read the data in the file by using readLine
            var rl = sr.ReadLine();
            // If the rl is not null, then print (is it correct?)....
            if(rl != null)
            {
                ///code to print data+
                info.Add(rl);
            }
            dgv.DataSource = info;
        }
    }
