    public static void SaveWorkbook(IWorkbook wb, string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
        {
            wb.Write(fs);
        }
    }
