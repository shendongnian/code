    public bool InsertEntry(string idnumber, string date, string time, string type, string remarks)
    {
        try
        {
            string line = $"\"{idnumber}\",\"{date}\",\"{time}\",\"{type}\",\"{remarks}\"";
            File.AppendAllText(data_path, line);
            return true;
        }
        catch (Exception ee)
        {
            string temp = ee.Message;
            return false;
        }
    }
