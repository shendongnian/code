    var dataForDateRange = obj.table.Where(m => m.id== id && m.CreatedDateTime >= start && m.CreatedDateTime<= end);
    StringBuilder csvBuilder = new StringBuilder();
    
    //Adding column header
    csvBuilder.AppendLine("Col1","Col2", "Col3", ....);
    //Adding row data
    for(int i = 0; i < dataForDateRange.Rows.Count; i++)
    {
        csvBuilder.Append(dataForDateRange.Rows[i] + ",");
        csvBuilder.Append("\n");
    }
    
    //Save your file
    public void SaveFileReport()
    {
        try
        {
            if(File.Exists("yourfilepath") == false) //eg @"c:\test.csv"
            {
                FileStream fstream = File.Create("yourfilepath"); 
                fstream.Close();
            }
            File.WriteAllText("yourfilepath", csvBuilder.ToString());
        }
        catch(Exception)
        {
            throw;
        }
    }
