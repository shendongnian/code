    // Server side
    public ActionResult GimmeFile()
    {
        var bytes = System.IO.File.ReadAllBytes(@"path_to_your_file.xlsx");
        return File(bytes, "application/vnd.ms-excel", "Myfile.xls");
    }
