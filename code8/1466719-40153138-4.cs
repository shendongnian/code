     var filesReadToProvider = await Request.Content.ReadAsMultipartAsync();
     foreach (var stream in filesReadToProvider.Contents)
	 switch (stream.Headers.ContentDisposition.Name)
                    {
                        case "\"file\"":
                            byte[] fileData = await stream.ReadAsByteArrayAsync();
                            break;
                        default:
                            break;
                    }
                }
