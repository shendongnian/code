    public void AddPictures(ExcelWorksheet ws, string filePath, int x,int y)
        {
            Image image = Image.FromFile(filePath);
            OfficeOpenXml.Drawing.ExcelPicture pic = 
            ws.Drawings.AddPicture("Pic1", image);
            //Set the postion of drawing picture  
            pic.SetPosition(x, y);          
            //Set the size of drawing picture  
            pic.SetSize(48);
        }
