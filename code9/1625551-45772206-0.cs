    public IActionResult ExportExcel()
    {
        FileStreamResult fsr = null;
        string excelPath = @"C:\Temp\Excel.xls";
        try
        {
                    
            var filename = Path.GetFileName(excelPath);
            Stream tempFileStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            fsr = new FileStreamResult(tempFileStream, MimeHelper.GetMimeType(filename));
        }
        catch (Exception e)
        {
            Log.Error(e, "Failed to read: {FILE}", excelPath);
            return fsr;
        }
    
        return fsr;
    }
