    public class UploadFilesResult
    {
    	public string Name { get; set; }
    	public int Length { get; set; }
    	public string Type { get; set; }
    }
    [HttpPost]
    public ContentResult UploadFiles()
    {
    	var r = new List<ViewDataUploadFilesResult>();
     
    	foreach (string file in Request.Files)
    	{
    		HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
    		if (hpf.ContentLength == 0)
    			continue;
     
    		string savedFileName = Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileName(hpf.FileName));
    		hpf.SaveAs(savedFileName); // Save the file
     
    		r.Add(new ViewDataUploadFilesResult()
    		{
    			Name = hpf.FileName,
    			Length = hpf.ContentLength,
    			Type = hpf.ContentType
    		});
    	}
    	// Returns json
    	return Content("{\"name\":\"" + r[0].Name + "\",\"type\":\"" + r[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", r[0].Length) + "\"}", "application/json");
    }
