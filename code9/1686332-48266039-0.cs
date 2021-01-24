    return new JsonResult()
                    {
                        Data = new
                        {
                            FileGuid = handle,
                            MimeType = System.Net.Mime.MediaTypeNames.Application.Zip,
                            FileName = "OT_" + OT.OT.ToString() + ".zip",
                            MaxJsonLength = Int32.MaxValue
                        }
                    };
