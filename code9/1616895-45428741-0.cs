    private DataTable GetDataTableFromCSVFile()
    {
        var data = new DataTable();
        data.Columns.Add("Column1", typeof(int));
        
        // Read lines of file
       
        // line is imaginery object which contains values of one row of csv data
        foreach(var line in lines) 
        {
            var row = data.NewRow();
            int.TryParse(line.Column1Value, out int column1Value)
            row.SetField("Column1", column1Value) // will set 0 if value is invalid
            // other columns
        }
        return data;
    }
