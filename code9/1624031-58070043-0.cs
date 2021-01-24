                    string requestString = @"https://example.com/path/file.pdf";
                    var GetTask = httpClient.GetAsync(requestString);
                    GetTask.Wait(WebCommsTimeout); // WebCommsTimeout is in milliseconds
                    if (!GetTask.Result.IsSuccessStatusCode)
                    {
                        // write an error
                        return;
                    }
                    
                    using (var fs = new FileStream(@"c:\path\file.pdf", FileMode.CreateNew))
                    {
                        var ResponseTask = GetTask.Result.Content.CopyToAsync(fs);
                        ResponseTask.Wait(WebCommsTimeout);
                    }
