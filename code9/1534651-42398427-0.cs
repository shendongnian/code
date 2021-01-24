    if(dt.Rows.Count > 0)
            {
                byte[] data = (byte[])dt.Rows[0][0];
                
                OpenPDF(data);                
            }
    protected void OpenPDF(byte [] data)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=\"image.pdf\"");
            HttpContext.Current.Response.BinaryWrite(data);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
            HttpContext.Current.Response.End();            
        }
