        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmlwritter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
		StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmlwritter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/ms-excel";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", "DSR"+DateTime.Now.ToString("dd-MM-yyyy")+".xls"));
		GridView1.RenderBeginTag(htmlwritter);
        GridView1.HeaderRow.RenderControl(htmlwritter);
        foreach (GridViewRow row in GridView1.Rows)
        {
            row.RenderControl(htmlwritter);
        }
        GridView1.FooterRow.RenderControl(htmlwritter);
        GridView1.RenderEndTag(htmlwritter);
		Response.Write(strwritter.ToString());
        Response.End();
