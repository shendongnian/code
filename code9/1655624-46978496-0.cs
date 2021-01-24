    using (db)
    {
        if (db.Projects.Any(p => p.NumberMCP == mcpc.NumberMCP)) 
    	{
    		// Handle error here
    	}
        mcpc.Proj = file.FileName;
        mcpc.ContentType = file.ContentType;
        mcpc.MCPcontent = buffer;
        db.Projects.Add(mcpc);
        db.SaveChanges();
    }
