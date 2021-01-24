            [HttpPost("CreateCountry")]
            public async Task<IActionResult> OnPostAsync(IFormFile file)
            {
                if (!ModelState.IsValid)
                    return Page();
                /*var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                        .Select(x => new { x.Key, x.Value.Errors })
                                        .ToArray();*/
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin); 
                    string pictureUrl = Shared.AzureCloud.AzureCDN.GetAzureCDNInstance().UploadFile(stream, file.Name);
                    try
                    {
                        if (pictureUrl != null)
                            Shared.Database.SqlAction.CountriesTable.AddCountry(new Country()
                            {
                                Name = Country.Name,
                                PictureUrl = pictureUrl
                            });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                return Page();
            }
