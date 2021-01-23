    protected void Page_Load(object sender, EventArgs e)
    		{
                string fullName = String.Empty;
    		    fileName = Request.Params["nazwa"];
                ext=Request.Params["ext"];
    		    fullName = fileName + "." + ext;
                byte[] bts = GetAttachment(dokumentDaneId);
                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = ContentType["."+ext].ToString();
                Response.AddHeader("content-disposition", "attachment; filename=" + fullName);
                Response.BufferOutput = true; ;
                Response.OutputStream.Write(bts, 0, bts.Length);
                Response.End();
    		}
