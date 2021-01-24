    public static bool ReadExcelFile(string pathToMedia)
            {
                try
                {
                    string filePath                 = pathToMedia;
                    string zipFilePath              = HttpContext.Current.Server.MapPath("~/www/UploadExcelFile");
                    string extractImagesTo          = HttpContext.Current.Server.MapPath("~/www/Images/AccessoriesZipImages");
                    string pathToExcelFileOnServer  = string.Empty;
    
    
    
                    using (ZipArchive archive = ZipFile.OpenRead(filePath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (entry.FullName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) ||entry.FullName.EndsWith("xls", StringComparison.OrdinalIgnoreCase))
                            {
                                if (File.Exists(Path.Combine(zipFilePath, entry.Name)))
                                {
                                    File.Delete(Path.Combine(zipFilePath, entry.Name));
                                }
    
                                pathToExcelFileOnServer = Path.Combine(zipFilePath, entry.Name);
                                entry.ExtractToFile(Path.Combine(zipFilePath, entry.Name));
                            }
                        }
                    }
    
    
                    using (ZipArchive archive = ZipFile.OpenRead(filePath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            if (File.Exists(Path.Combine(extractImagesTo, entry.Name)))
                            {
                                File.Delete(Path.Combine(extractImagesTo, entry.Name));
                            }
    
                            if (entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || entry.FullName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                            {
                                entry.ExtractToFile(Path.Combine(extractImagesTo, entry.Name));
                            }
                        }
                    }
    
                    if (!string.IsNullOrEmpty(pathToExcelFileOnServer))
                    {
                        using (var stream = File.Open(pathToExcelFileOnServer, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet();
    
                                List<ShoppingCartViewModel> excelList = new List<ShoppingCartViewModel>();
    
                                foreach (DataTable table in result.Tables)
                                {
                                    foreach (DataRow dr in table.Rows.Cast<DataRow>().Skip(1)) //Skipping header
                                    {
                                        //Cannot seem to use cell names, so use cell location
                                        excelList.Add(new ShoppingCartViewModel(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), Path.Combine(extractImagesTo, dr[3].ToString()), dr[4].ToString(), null, 0.00, null));
                                    }
                                }
    
                                var contentService  = ApplicationContext.Current.Services.ContentService;
                                var allEventsNode   = ExcelUploadUmbracoAssignedContentHelper.HomePageContent();
                                int rootId          = allEventsNode.Id;
                                var itemsForSale    = contentService.GetChildren(rootId).Where(x => x.ContentType.Alias == "accessorieItems").ToList();
    
                                //Delete all current nodes                      
                                foreach (var items in itemsForSale)
                                {
                                    contentService.Delete(items);
                                }
    
                                foreach (var item in excelList)
                                {
                                    string fileName             = Guid.NewGuid().ToString();
                                    var content                 = contentService.CreateContent(item.Product, allEventsNode.Id,"accessorieItems");
                                    IMediaService mediaService  = ApplicationContext.Current.Services.MediaService;
                                    var newImage                = mediaService.CreateMedia($"{fileName}.jpeg", -1, "Image");
                                    byte[] buffer               = File.ReadAllBytes(Path.GetFullPath(item.ProductUrl));
                                    MemoryStream strm           = new MemoryStream(buffer);
    
                                    newImage.SetValue("umbracoFile", $"{fileName}.jpeg", strm);
                                    mediaService.Save(newImage);
    
                                    var umbracoHelper   = new UmbracoHelper(UmbracoContext.Current);
                                    var image           = umbracoHelper.Media(newImage.Id).Url;
                                    string imagePath    = image.ToString();
    
                                    content.SetValue("productId", item.ProductId);
                                    content.SetValue("productTitle", item.Product);
                                    content.SetValue("productPrice", item.Price);
                                    content.SetValue("productImage", imagePath);
                                    content.SetValue("productDescription", item.ProductDescription);
                                    contentService.SaveAndPublishWithStatus(content);
                                }
    
                                contentService.RePublishAll();
                                library.RefreshContent();
    
                                Array.ForEach(Directory.GetFiles(extractImagesTo), File.Delete);
                                //Delete empty folders in media folder
                                DeleteEmptyFolder.DeleteFolder();
                            }
                        }
                    }
    
                    return true;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(ex.ToString());
                }
            } 
