    for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];
        
                if (file != null && file.ContentLength > 0)
                {
         var fileName = guid + i.ToString() + Path.GetExtension(file.FileName)); 
    
    var path = Path.Combine(Server.MapPath("~/Content/admin/Upload"), fileName);
    
     file.SaveAs(path); 
    
    i++; 
                }
             }
