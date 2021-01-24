    //Post method for Image upload
         [HttpPost]
                public async Task<JsonResult> AddPromotion(AddPromotionDto addpromotions)
                {
                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string promotionImage;
                            addpromotions.PromotionImage = file.FileName;
                            promotionImage = Path.Combine(Server.MapPath("../Image/"), addpromotions.PromotionImage);
                            file.SaveAs(promotionImage);
                            using (var fileStream = new MemoryStream())
                            {
                                using (var oldImage = new Bitmap(file.InputStream))
                                {
                                    var format = oldImage.RawFormat;
                                    string fileName = promotionImage;
                                    using (var newImage = ResizeImage(oldImage, 800, 2000))
                                    {
                                        Graphics graphicsImage = Graphics.FromImage(newImage);
                                        StringFormat stringformat = new StringFormat();
                                        stringformat.Alignment = StringAlignment.Far;
                                        stringformat.LineAlignment = StringAlignment.Far;
                                        StringFormat stringformat2 = new StringFormat();
                                        stringformat2.Alignment = StringAlignment.Center;
                                        stringformat2.LineAlignment = StringAlignment.Center;
                                        Color StringColor = System.Drawing.ColorTranslator.FromHtml("#e80c88");
                                        string Str_TextOnImage = addpromotions.PromotionName;
                                        graphicsImage.DrawString(Str_TextOnImage, new Font("arial", 40,
                                        FontStyle.Regular), new SolidBrush(StringColor), new Point(500, 300),
                                        stringformat);
                                        Response.ContentType = "image/jpeg";
                                        newImage.Save(fileName, format); // for overwrite the previous image
                                    }
                                }
                            }
                        }
                    }
                    await companyManager.AddPromotion(User.Identity.Name, addpromotions);
                    return Json("Promotions", JsonRequestBehavior.AllowGet);
                }
        
        
        // Method for resize the image
         public static Bitmap ResizeImage(Bitmap image, int width, int height)
                {
                    if (image.Width <= width && image.Height <= height)
                    {
                        return image;
                    }
                    int newWidth;
                    int newHeight;
                    if (image.Width > image.Height)
                    {
                        newWidth = width;
                        newHeight = (int)(image.Height * ((float)width / image.Width));
                    }
                    else
                    {
                        newHeight = height;
                        newWidth = (int)(image.Width * ((float)height / image.Height));
                    }
                    var newImage = new Bitmap(newWidth, newHeight);
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        graphics.FillRectangle(Brushes.Transparent, 0, 0, newWidth, newHeight);
                        graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                        return newImage;
                    }
                }
