    public ActionResult Test()
    {
        foreach (HttpPostedFileBase thisPic in this.Request.Files)
        {
            using (var reader = new StreamReader(thisPic.InputStream))
            {
                // call methods on reader such as reader.ReadLine() etc.
            }
        }
    }
