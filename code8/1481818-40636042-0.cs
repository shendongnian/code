        public class ControllerHelper
    {
        public void DeleteChain(int? chainId)
        {
    	using (UranusContext db = new UranusContext())
    	{
    	        var chain = db.Chains.Include(c => c.Sheets)
            	    .SingleOrDefault(c => c.ChainId == chainId);
    
    	        // Removes sheets (children)
            	foreach (var sheet in chain.Sheets.ToList())
    	        {
    	            DeleteSheet(sheet.SheetId, db);
    	        }
    
    	        db.Chains.Remove(chain);
    	        db.SaveChanges();
    	}
        }
    
        public void DeleteSheet(int? sheetId, UranusContext db)
        {
            var sheet = db.Sheets.Include(s => s.FileDetails)
                .Include(s => s.SheetsCounties)
                .SingleOrDefault(s => s.SheetId == sheetId);
    
            foreach (var fileDetails in sheet.FileDetails.ToList())
            {
                db.FileDetails.Remove(fileDetails);
            }
    
            foreach (var sheetsCounties in sheet.SheetsCounties.ToList())
            {
                db.SheetsCounties.Remove(sheetsCounties);
            }
    
            db.Sheets.Remove(sheet);
            db.SaveChanges();
        }
    }
