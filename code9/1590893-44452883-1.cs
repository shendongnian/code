      public bool InsertEntrie(string idnumber, string date, string time, string 
      type, string remarks)
        {            
            CreateConfigFile();
            try
            {
               string line = $"\"{idnumber}\",\"{date}\",\"{time}\",\"
                {type}\",\"{remarks}\"{Environment.NewLine}";
                File.AppendAllText(data_path, line);                
                return true;
            }
            catch (Exception ee)
            {
                string temp = ee.Message;
                return false;
            }
        }
