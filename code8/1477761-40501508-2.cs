    string FileName = dateTimeStamp + "SiteReservation.doc";
                if (FileName != "")
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(path + dateTimeStamp + "SiteReservation.doc");
                    if (file.Exists)
                    {
                        Response.Clear();
                        Response.AddHeader("Content-Disposition", "attachment; filename=SiteReservation.doc");
                        Response.AddHeader("Content-Length", file.Length.ToString());
                        Response.ContentType = "application/octet-stream";
                        Response.WriteFile(file.FullName);
                        //Response.End();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        Response.Write("This file does not exist.");
                    }
                }
