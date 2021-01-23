    public JsonResult GenerateCrystalReportImage()
    {
    	List<ImageModel> list_image = new List<ImageModel>();
        //
    	ImageModel imageone = new ImageModel();
    	imageone.Id = 1;
    	imageone.Name = "Image name one";
    	imageone.Description = "This is a image description one";
    	imageone.Image = GetImageBytes("imageone.png");
    	list_image.Add(imageone);
        //
    	ImageModel imagetwo = new ImageModel();
    	imagetwo.Id = 2;
    	imagetwo.Name = "Image name two";
    	imagetwo.Description = "This is a image description two";
    	imagetwo.Image = GetImageBytes("imagetwo.png");
    	list_image.Add(imagetwo);
    	//
    	ReportDocument rp = new ReportDocument();
    	rp.Load(System.Web.HttpContext.Current.Server.MapPath("~/Reports/") + "Test.rpt");
    	rp.SetDataSource(list_image);
    	rp.ExportToHttpResponse(ExportFormatType.PortableDocFormat, 
    	                        System.Web.HttpContext.Current.Response, 
    							false, 
    							"image_list_" + DateTime.Now);
        rp.Close();
    	return Json(new
    	{
    		data = "ok",
    		results = 1,
    		success = true,
    		errors = String.Empty
    	}, JsonRequestBehavior.AllowGet);
    }
