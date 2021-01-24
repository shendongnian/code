    // This will close the file handle after writing the data
    File.WriteAllBytes(name, documentBytes);
    // Then you're fine to get Excel to open it
    var app = new Microsoft.Office.Interop.Excel.Application();
    app.Visible = false;
    var workbook = app.Workbooks.Open(name);
                
