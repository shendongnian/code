    if(openFile.ShowDialog() == DialogResult.OK)
    {
        string dataLine = string.Empty;
        using (StreamReader read = new StreamReader(File.OpenRead(openFile.FileName)))
        {
            //Changed happened here
        
            dataLine = read.ReadToEnd();
            string[] beginningOfData = dataLine.Split(',');
            string temporary = string.Empty;
            if(beginningOfData.Contains("Indicator"))
            {   
               temporary = dataLine.Substring(9);
               foreach(string realData in beginningOfData)
               {
                 //Goes through file
               }
            }
            else
            {
              MessageBox.Show("Can't load data");
            }
        }
    }  
