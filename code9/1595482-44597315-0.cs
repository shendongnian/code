    if (beginningOfData.All(line => line.ToLower().Contains("indicator")))
    {
        string temporary = string.Empty;
        foreach (string line in beginningOfData)
        {
            temporary = line.Substring(9);
            //Goes through the rest of the file
            //Converts data to control value and adds it
        }
    }
    else
    {
        System.Windows.Forms.MessageBox.Show("Can't load data.");   
    }
