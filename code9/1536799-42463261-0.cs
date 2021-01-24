    foreach (HttpPostedFileBase file in model.SecondaryFiles)
    {
        // FurnitureImages images = new FurnitureImages(); -- DELETE
        if (file != null && file.ContentLength > 0)
        {
            string displayName = file.FileName;
            string extension = Path.GetExtension(displayName);
            string fileName = string.Format("{0}{1}", Guid.NewGuid(), extension);
            var path = "~/Upload/" + fileName;
            file.SaveAs(Server.MapPath(path));
            // Add a new ImageVM to the collection 
            model.SecondaryImages.Add(new ImageVM { DisplayName = displayName, Path = path });
        }
    }
