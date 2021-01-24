          int i = 2;
      foreach (var item in chartProduct)
      {
        ws.Cells[i, 1].Value = item.Id;
        ws.Cells[i, 1].Style.Font.Bold = true;
        ws.Cells[i, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
     // string imagePath = _hostingEnvironment.WebRootPath + 
    //$@"\images\product\" + item.ImageUrl;
    string filePath= "~/images/product/" + item.ImageUrl;
     AddPictures(ws, filePath,i,2);
       ws.Cells[i, 3].Value = item.Material.Code;
        ws.Cells[i, 3].Style.Font.Bold = true;
        ws.Cells[i, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        ws.Cells[i, 4].Value = item.Material.Name;
        ws.Cells[i, 4].Style.Font.Bold = true;
        ws.Cells[i, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        ws.Cells[i, 5].Value = item.Code;
        ws.Cells[i, 5].Style.Font.Bold = true;
        ws.Cells[i, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        ws.Cells[i, 6].Value = item.Name;
        ws.Cells[i, 6].Style.Font.Bold = true;
        ws.Cells[i, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
      i++;
      }
