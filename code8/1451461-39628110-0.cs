    using (ExcelPackage p = new ExcelPackage())
    {
        //Code to fill Excel file with data.
                 
        Byte[] bin = p.GetAsByteArray();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", Nombre_Del_Libro + ".xlsx"));
        Response.BinaryWrite(bin);
        Response.Flush();
        Response.End();
    }   
