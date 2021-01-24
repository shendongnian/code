    public void AddPictures(ExcelWorksheet ws, string filePath,int row,int col)
        {
            Image image = Image.FromFile(filePath);
            OfficeOpenXml.Drawing.ExcelPicture pic =ws.Drawings.AddPicture(string.Format("Pic{0}",row), image);      
            pic.SetPosition(row-1, 0,0,0);
            pic.SetSize(50,50);
        }
