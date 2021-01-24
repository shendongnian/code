    var newFile = new FileInfo("pathToNewFile.xlsx");
    var templateFile = new FileInfo("PathToTemplate.xlsx");
    using(var pck = new ExcelPackage(newFile,templateFile))
    {
        var ws=pck.Workbook.Worksheets[0];
    
        //Set a cell's text
        ws.Cells["A1"].Value ="whatever";
        ws.Cells[2,1].Value ="whatever2";
        
        //Fill cells from a collection
        var orders=new List<Order>();
       //Fill the list then ...
        ws.Cells["A10"].LoadFromCollection(orders);
        
        pck.Save();
     }
