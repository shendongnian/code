        List<string> result = Directory.EnumerateFiles(filepath, "*.pdf", System.IO.SearchOption.TopDirectoryOnly).Union(Directory.EnumerateFiles(filepath, "*.tif", System.IO.SearchOption.TopDirectoryOnly)).ToList();
            Parallel.ForEach(result, new ParallelOptions { MaxDegreeOfParallelism=3}, file =>
           {
                try
                 {
                    GdPictureStatus status = new GdPictureStatus();
                    GdPictureImaging oGdPictureImaging = new GdPictureImaging();
                    GdPicturePDF oGdPicturePDF = new GdPicturePDF();
                    status = oGdPicturePDF.LoadFromFile(file, false);
             if (status == GdPictureStatus.OK)
           {
             string batchDate = filepath.Substring(filepath.LastIndexOf("\\") + 1);
             string padding = String.Empty;
             string filePath = string.Empty;
            
             FileInfo _pdFileInfo = new FileInfo(file);
             string batchDir = filepath + "\\Batches\\" + _pdFileInfo.Name.Split('.')[0] + "." + batchDate.Substring(6, 2) + batchDate.Substring(4, 2);
            string batchname = _pdFileInfo.Name.Split('.')[0] + "." + batchDate.Substring(6, 2) + batchDate.Substring(4, 2);
             if (!Directory.Exists(batchDir))
            {
              Directory.CreateDirectory(batchDir);
             }
             for (int i = 1; i <= oGdPicturePDF.GetPageCount(); i++)
             {
             //select page
              oGdPicturePDF.SelectPage(i);
             //render selected page to GdPictureImage identifier
            int rasterizedPageID = oGdPicturePDF.RenderPageToGdPictureImageEx(200.0f, true);
            
                                            if (i == 1 || i < 10)
                                            {
                                                padding = "00";
                                            }
                                            else if (i == 10 || i < 100)
                                            {
                                                padding = "0";
                                            }
                                            else
                                            {
                                                padding = string.Empty;
                                            }
            
                //Set Image file name
              filePath = batchDir + "\\" + padding + i + ".tif";
            
              // Converting to black and White
    oGdPictureImaging.FxBlackNWhite(rasterizedPageID, BitonalReduction.Stucki);
             // Converting to Single pixel
    oGdPictureImaging.ConvertTo1BppAT(rasterizedPageID);
            
            // Saving each page of the PDF file to single TIFF image
             status = oGdPictureImaging.SaveAsTIFF(rasterizedPageID, filePath, false, tiffType);
                                            oGdPictureImaging.ReleaseGdPictureImage(rasterizedPageID);
                }
                }
            
                                    oGdPictureImaging.Dispose();
                                    oGdPicturePDF.Dispose();
                                    
                                }
                                catch (Exception g)
                                {
                                    throw new ApplicationException(g.Message + file);
                                    
                                    return;
                                }
                            }
            
                            );
                        }
