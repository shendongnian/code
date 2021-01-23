                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Length", PDFByteArray.Length.ToString());
                Response.AddHeader("Content-Disposition", "inline");
                Response.AddHeader("Cache-Control", "public");
                Response.OutputStream.Write(PDFByteArray, 0, PDFByteArray.Length);
                Response.Flush();
                Response.End();
