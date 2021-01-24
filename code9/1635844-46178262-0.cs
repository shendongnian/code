     [System.Web.Services.WebMethod]
     public static void Upload()
     {
     
     
         for (int i = 0; i < Request.Files.Count; i++)
         {
             var file = Request.Files[i];
     
             var fileName = Path.GetFileName(file.FileName);
     
             var path = Path.Combine(Server.MapPath("~/Uploads/"), fileName);
             file.SaveAs(path);
         }
     
     }
