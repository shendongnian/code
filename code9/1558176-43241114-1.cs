    public bool Load(string calendarEntriesFile)
    {
        bool status = true;
        this.calendarEntriesFile = calendarEntriesFile; //store path for future use
    
        if (!File.Exists(calendarEntriesFile))
        {
            status = false;
            File.Create(calendarEntriesFile).Close(); //create the file as it do not exists
        }
        else
            FillList(); // File exists! :) then what are we waiting for lets read it .  .
    
        return status;
    }
    
    private void FillList()
    {
        try
        {
            using (StreamReader rd = new StreamReader(calendarEntriesFile))
            {
                string line = rd.ReadLine();
                while (line != null)// read line by line in file all apointments
                {
                    string[] data = line.Split('#');
                    Row row = new Row();
                    row.Adopt(data);//create a row of current line i.e appointment
                    this.Add(row); // add it to the current list for display
                    line = rd.ReadLine();
                }
    
                rd.Close();
            }
        }
        catch
        {
            MessageBox.Show("Error Occured while reading the appointments File!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    public bool Save(string[] data)
    {
        try
        {
            string line = null;
            for (int i = 0; i < data.Length; i++)
            {
                line += data[i] + "#";
            }
            line = line.Remove(line.Length - 1);
    
            using (StreamWriter writer = new StreamWriter(calendarEntriesFile, true))
            {
                writer.WriteLine(line);
                writer.Close();
            }
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            return false;
        }
    }
