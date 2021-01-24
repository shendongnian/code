    using (var magicImage = new MagickImage())
                {
                    var magicReadSettings = new MagickReadSettings
                    {
                        Format = MagickFormat.Svg,
                        ColorSpace = ColorSpace.Transparent,
                        BackgroundColor = MagickColors.Transparent,
                        // increasing the Density here makes a larger and sharper output to PNG
                        Density = new Density(950, DensityUnit.PixelsPerInch)
                    };
    
                    magicImage.Read("someimage.svg", magicReadSettings);
                    magicImage.Format = MagickFormat.Png;
                                                  
                    magicImage.Write("someimage.png");
    
                }
