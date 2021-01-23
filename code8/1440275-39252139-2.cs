    {
        List<ContentDisplay> model = new List<ContentDisplay>();
        if (file != null && file.ContentLength > 0)
        {
            var fileName = System.IO.Path.GetFileName(file.FileName);
            var path = System.IO.Path.Combine(("C:\\Dev\\ProductionOrderWebApp\\Uploads"), fileName);
            file.SaveAs(path);
            await CSVRead.CSVReader(path); //calls a method that reads and takes apart a CSV file
            model = await DatabaseRead.MongoReader(path);
        }
        return View("Display", model);
    }
