                        Image image = new Image();
                        if (file.ContentLength > 0)
                        {
                            file.SaveAs(HttpContext.Server.MapPath("~/Img/") + file.FileName);
                            image.ImagePath = file.FileName;
                        }
                        repository.Create(image);
