    using (var img = System.Drawing.Image.FromFile(Server.MapPath(pictureModel.ImageUrl))) // Image Path from File Upload Controller
                        {
                            using (var memStream = new MemoryStream())
                            {
                                img.Save(memStream, img.RawFormat);
                                byte[] imageBytes = memStream.ToArray();
                                // Convert byte[] to Base64 String
                                base64String = Convert.ToBase64String(imageBytes);
                                string ImageBase64 = base64String;
                                //   return base64String;
                            }
                        }
