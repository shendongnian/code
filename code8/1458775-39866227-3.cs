    public ActionResult Create(MyModel model)
    {
        if (!ModelState.IsValid)
        {
            .... // code as above to save temporary file and return the view
        }
        // Initialize an instance of your data model
        var dataModel = new .... // assumes this contains a property byte[] Image
        if (model.FilePath == null)
        {
            // The code above has never run so read from the HttpPostedFileBase property
            if(model.Image != null && model.Image.ContentLength > 0) {
            {
                MemoryStream target = new MemoryStream();
                model.Image.InputStream.CopyTo(target);
                dataModel.Image = target.ToArray();
            }
        }
        else
        {
            // Read from the temporary file
            dataModel.Image = System.IO.File.ReadAllBytes(filename);
            .... // Delete the temporary file
        }
        // Map other properties of your view model to the data model
        // Save and redirect
    }
