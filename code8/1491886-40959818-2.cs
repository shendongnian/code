    Directory.GetFiles(sourceDir))
                        .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
                        .Select(imageFile => new Photo()
                        {
                            ShowOrder = ++fileOrder,
                            Image = File.ReadAllBytes(imageFile),
                            Format = Path.GetExtension(imageFile)
                        }
                        ).ToList()
