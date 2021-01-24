    using (var sr = new System.IO.StreamReader(HttpContext.Server.MapPath("~/content/data.csv")))
    {
         String line;
         while ((line = sr.ReadLine()) != null)
         {
    	     // combine source strings here
         }
    }
