    namespace FileUploadApplication.Controllers
        {
            public class FileController : Controller
            {
    
    			[HttpGet]
    			public ActionResult Index()
    			{
    				return View();
    			}
    
                [HttpPost]
                public ActionResult Index(HttpPostedFileBase file)
                {
                    if (file != null && file.ContentLength > 0)
                        try
                        {
                            string path = Path.Combine(Server.MapPath("~/Images"),
                                                       Path.GetFileName(file.FileName));
                            file.SaveAs(path);
                            ViewBag.Message = "File uploaded successfully";
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
                    else
                    {
                        ViewBag.Message = "You have not specified a file.";
                    }
                    return View();
                }
            }
        }
    
