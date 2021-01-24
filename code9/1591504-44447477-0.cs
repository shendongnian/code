                //Now write the image...
                if (GameInfo.blTSImagePresent == true)
                {
                    var TSImage = archive.CreateEntry("imgTSImage");
                    using (var entryStream = TSImage.Open())
                    {
                        GameInfo.imgTSImage.Save(entryStream, ImageFormat.Jpeg);
                    }
                    
                }
