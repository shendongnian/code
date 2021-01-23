    string attachment = "attachment; filename=exported_file.xls";
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            StringWriter stw = new StringWriter();
            HtmlTextWriter htextw = new HtmlTextWriter(stw);
            ctl.RenderControl(htextw);
            HttpContext.Current.Response.Write(stw.ToString());
            FileInfo fi = new FileInfo(Server.MapPath("../Content/Styles/StyleSheet.css"));
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            StreamReader sr = fi.OpenText();
            while (sr.Peek() >= 0)
            {
                sb.Append(sr.ReadLine());
            }
            sr.Close();
            Response.Write("<html><head><style type='text/css'>" + sb.ToString() + "</style></head>" + stw.ToString() + "</html>");
            stw = null;
            htextw = null;
            Response.Flush();
            Response.End();
