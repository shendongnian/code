                string filepath = @"C:\docs\result.pdf";
                byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                string contentType = System.Web.MimeMapping.GetMimeMapping(filepath);
                var cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = "result.pdf",
                    Inline = false,
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(filedata, contentType);
