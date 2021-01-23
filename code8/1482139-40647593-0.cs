    var ns = new ControllerName ();
    
    var path = ns.RenderImage("id", "path");  
     var fileResult = path  as FilePathResult;
    
        if (fileResult != null)
        {
            
            string imageurl = fileResult.FileName;
        }
