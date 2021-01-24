    if (FileUpload1.HasFile)
                {
                    long fileSize = FileUpload1.FileContent.Length;
                    double sizeinBytes = fileSize * 0.001;
                    FileUpload1.SaveAs(Server.MapPath("~/junk/" + FileUpload1.FileName));
                    string filepath = Server.MapPath("~/junk/" + FileUpload1.FileName);
    
                    using (System.IO.FileStream fs = System.IO.File.OpenRead(filepath))
                    {
                        byte[] data = new byte[fs.Length];
                        fs.Read(data, 0, data.Length);
    
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                        Bitmap resizedimage = ResizeImage(image, 500, 500);
                        resizedimage.Save(Server.MapPath("~/images/" + FileUpload1.FileName + ".jpeg"));
                    }
                    Image1.ImageUrl = "~/images/" + FileUpload1.FileName;
                    var filePath = Server.MapPath("~/junk/" + FileUpload1.FileName);
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
