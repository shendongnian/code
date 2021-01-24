    { 
        DataTable dtpic;
             dtpic = DBData.getDataTable(DBData.DataPath, "select * from Table");
       ZipFile zip = new ZipFile();
        foreach (DataRow dr in dtpic.Rows)
        {
            zip.AddEntry(dr["UploadedFileName"].ToString(), (byte[])dr["Photo1"]);
        }
        var zipMs = new MemoryStream();
        zip.Save(zipMs);
        byte[] fileData = zipMs.ToArray();
        zipMs.Seek(0, SeekOrigin.Begin);
        zipMs.Flush();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=docs.zip ");
        Response.ContentType = "application/zip";
        Response.BinaryWrite(fileData);
        Response.End();
    }
