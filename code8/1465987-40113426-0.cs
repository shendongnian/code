                    byte[] bin;
                    using (MemoryStream stream = new MemoryStream())
                    {
                        document.Save(stream, false);
                        bin = stream.ToArray();
                    }
                    Response.ClearHeaders();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", bin.Length.ToString());
                    Response.AddHeader("content-disposition", "attachment; filename=\"MyCertificate.pdf\"");
                    Response.OutputStream.Write(bin, 0, bin.Length);
                    Response.Flush();
                    Response.Close();
                    Response.End();
