    [HttpPost]
    [Route("api/dashboard/UploadImage")]
    public HttpResponseMessage UploadImage()
            {
                string imageName = null;
                var httpRequest = HttpContext.Current.Request;
                //Upload Image
                var postedFile = httpRequest.Files["Image"];
                //Create custom filename
                if (postedFile != null)
                {
                    imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
                    var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
                    postedFile.SaveAs(filePath);
                }
    }
