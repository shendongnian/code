            //get the root folder where file will be store
            string root = HttpContext.Current.Server.MapPath("~/UploadFile");
            // Read the form data.
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);
            if (provider.FileData.Count > 0 && provider.FileData[0] != null)
            {
                MultipartFileData file = provider.FileData[0];
                //clean the file name
                var fileWithoutQuote = file.Headers.ContentDisposition.FileName.Substring(1, file.Headers.ContentDisposition.FileName.Length - 2);
                
                //get current file directory on the server
                var directory = Path.GetDirectoryName(file.LocalFileName);
                if (directory != null)
                {
                    //generate new random file name (not mandatory)
                    var randomFileName = Path.Combine(directory, Path.GetRandomFileName());
                    var fileExtension = Path.GetExtension(fileWithoutQuote);
                    var newfilename = Path.ChangeExtension(randomFileName, fileExtension);
                    
                    //Move file to rename existing upload file name with new random filr name
                    File.Move(file.LocalFileName, newfilename);
                }
            }
