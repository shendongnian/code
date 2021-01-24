    public ActionResult Home(MultipleFilesForm form)
    {
            var guid = Guid.NewGuid().ToString();
            someclass.filename = guid;
            int i = 0;
    
        if(form.file1 != null)
        {
                 var file = form.file1;
                 if (file.ContentLength > 0)
                 {
                    var fileName = guid + i.ToString() + Path.GetExtension(file.FileName));
                    var path = Path.Combine(Server.MapPath("~/Content/admin/Upload"), fileName);
                    file.SaveAs(path);
                    i++;                         
                 }
        }
        if(form.file2 != null)
        {
            //handle file
        }
    
        ...
    }
