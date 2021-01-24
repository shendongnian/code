    string fileext = Path.GetExtension(fupcsv.PostedFile.FileName);
    if (fileext == ".csv")
    {
        string csvPath = Server.MapPath("~/CSVFiles/") + Path.GetFileName(fupcsv.PostedFile.FileName);
    
        fupcsv.SaveAs(csvPath);
        DataTable dtCSV = new DataTable();    
        dtCSV.Columns.AddRange(new DataColumn[2] { new DataColumn("ModuleId", typeof(int)), new DataColumn("CourseId", typeof(int))});
        var csvData = File.ReadAllLines(csvPath);
        bool headersSkipped = false;
        foreach (string line in csvData)
       	{
       		if (!headersSkipped)
       		{
       			headersSkipped = true;
       			continue;
       		}
       		// Check for is null or empty row record  
       		if (!string.IsNullOrEmpty(line))
       		{
       			//Process row
       			int i = 0;
       			var row = dtCSV.NewRow();
       			foreach (var cell in line.Split(','))
       			{
       				row[i] = Int32.Parse(cell);
       				i++;
       			}
       			dtCSV.Rows.Add(row);
       			dtCSV.AcceptChanges();
       		}
       	}
    }
