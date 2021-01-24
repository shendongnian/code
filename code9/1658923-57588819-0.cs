    public static string MakeFileUniqueName(this IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                string fileName =
                    ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim('"');
                // concatinating  FileName + FileExtension
                return Guid.NewGuid() + Path.GetExtension(fileName);      
            }
            return string.Empty;
        }
