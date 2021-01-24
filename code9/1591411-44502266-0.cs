    using (var stream = new MemoryStream())
    {
        Response.Clear();
        wb.Write(stream);
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "CCR Student Instructional Hours.xlsx"));
        Response.BinaryWrite(stream.ToArray());
        Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        Response.Close();
    }
