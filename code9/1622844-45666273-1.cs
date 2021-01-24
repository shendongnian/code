    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("mycontroller/uploaddoc")]//same as formaction
    public async Task<ActionResult> UploadDoc(FormCollection data, int typeid)
    {
        //restore inpput name
        var fl = Request.Files["doc:" + typeid.ToString() + ":upload"];
        if (fl != null && fl.ContentLength > 0)
        {
            var path = Server.MapPath("~/app_data/docs");
            var fn = Guid.NewGuid().ToString();//random name
            using (FileStream fs = System.IO.File.Create(Path.Combine(path, fn)))
            {
                await fl.InputStream.CopyToAsync(fs);
            }
        }
    }
