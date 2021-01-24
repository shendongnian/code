    var results = GetResults(); //However you retrieve your collection from DB
    
    var groupedResults = results.GroupBy(a => new { 
        a.Case_Number, 
        a.Docket, 
        a.Agency_Name, 
        a.Report_Number}).Select(b => b.FirstOrDefault());
    foreach(var group in groupedResults)      
    {
        // Fill the cells
        foreach(var payment in results.Where(a => a.ID == group.ID)
        {
            // Fill the payment detail cells and increment the row counter
        }
    }
