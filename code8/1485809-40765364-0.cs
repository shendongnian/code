     //First get your ImageId
                    string imgId= header.Descendants<Picture>().First().BlipFill.Blip.Embed.Value;
                    //Create a new BitmapImage
                    BitmapImage imageSource = new BitmapImage();
                    //Get the Picture stream and load it to the BitmapImage
                    using (var imgStream = ((ImagePart) document.MainDocumentPart.GetPartById(imgId)).GetStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            imgStream.CopyTo(memoryStream);
                            imageSource.BeginInit();
                            imageSource.StreamSource = memoryStream;
                            imageSource.EndInit();
                          }
                    }
                    //Here you get an Image object from your Picture
                    Image img = new Image {Source = imageSource};
