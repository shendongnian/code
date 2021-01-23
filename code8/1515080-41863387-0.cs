     using (System.Drawing.Image image = System.Drawing.Image.FromFile(filenamer))
                                    {
                                        using (MemoryStream m = new MemoryStream())
                                        {
                                            image.Save(m, image.RawFormat);
                                            byte[] imageBytes = m.ToArray();
                                            // Convert byte[] to Base64 String
                                            string base64String = Convert.ToBase64String(imageBytes);
                                            resendBack = base64String;  
                                        }
                                    }
