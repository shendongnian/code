    // Your url, eg. /<controller>/exclusions
    public ActionResult Exclusions()
    {
        var viewmodel = GetStoredProc();
        
        // pass your IEnumerable<Exclusion> to the view
        return View(viewmodel);
    }
    
    // Note the return type
    public IEnumerable<Exclusion> GetStoredProc()
    {
        var exclusions = new List<Exclusion>();
        
    
        // ... ...
    
        if (reader.HasRows)
        {
            int count = reader.FieldCount;
    
            while (reader.Read())
            {
                Exclusion objExclusion = new Exclusion(); // create a new exclusion for each row!
                if (count > 3)
                {
                    int IntNum;
                    int.TryParse(reader.GetValue(0).ToString(), out IntNum);
                    objExclusion.PolicyNo = IntNum;
                    objExclusion.PolicyMod = (reader.GetValue(1).ToString());
                    objExclusion.InsuredName = (reader.GetValue(2).ToString());
                    objExclusion.ClientID = IntNum;                   
                    exclusions.Add(objExclusion); // add the exclusion to your result set!
                }
            }
        }
    
        // Data is accessible through the DataReader object here.
        sqlConnection1.Close();
        return exclusions;
    }
