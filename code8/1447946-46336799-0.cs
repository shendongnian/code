            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fileName, Encoding.UTF8) + "");
            Response.Cookies.Add(new System.Web.HttpCookie("fileDownload", "true"));
            Response.Charset = "";
            Response.ContentType = "application/csv";
            Response.ContentEncoding = Encoding.UTF8;
            Response.BinaryWrite(Encoding.UTF8.GetPreamble());
            Response.Write(outPutStringData); // Information which you want in .csv file
            Response.Flush();
            Response.End();
