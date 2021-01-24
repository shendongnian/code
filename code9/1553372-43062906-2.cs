    private void metroButton13_Click(object sender, EventArgs e) 
    {
        DialogResult result = openFileDialog1.ShowDialog();
        int size =0;
        string file = string.empty;
        if (result == DialogResult.OK) // Test result.
        {
           string file = openFileDialog1.FileName;
           try
           {
              string text = File.ReadAllText(file);
              size = text.Length;
           }
           catch (IOException)
           {
           }
        }
        if(size >0) 
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(file);
            dataGridView1.DataSource = dataSet.Tables[0];
        }
        else 
        {
          msgbox ("blank file");
        }
    }
