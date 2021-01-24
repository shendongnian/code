     public ActionResult SaveDetails()
        {
            Request.InputStream.Seek(0, SeekOrigin.Begin);
            string jsonData = new StreamReader(Request.InputStream).ReadToEnd();
            PropertyDetailsViewModel PropertyDetail = JsonConvert.DeserializeObject<PropertyDetailsViewModel>(jsonData);
      
            if (PropertyDetail != null)
             {
             return Json("Success");
            }
            return Json("Failed");
        }
 
