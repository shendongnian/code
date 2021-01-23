    public class FileUploadController : ApiController
    {
        [HttpPost()]
        public string UploadFiles()
        {
            string sPath = HostingEnvironment.MapPath("~/UploadDocs/");
            int iUploadedCnt = 0;
            
            HttpFileCollection filesCollection = HttpContext.Current.Request.Files;
            string id = HttpContext.Current.Request.Form["Id"];
            for (int i = 0; i <= filesCollection.Count - 1; i++)
            {
                HttpPostedFile file = filesCollection[i];
                if (file.ContentLength > 0)
                {
                    if (!File.Exists(sPath + Path.GetFileName(file.FileName)))
                    {                        
                        file.SaveAs(sPath + Path.GetFileName(file.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
            }
            
            if (iUploadedCnt > 0)
            {
                return iUploadedCnt + " Files Uploaded Successfully";
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
