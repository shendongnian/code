    public class LocalUploader
        {
            public string UploadToServer(byte[] image, string fileName)
            {
                var localPath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
                var root = HttpContext.Current.Server.MapPath(@"/Uploads/");
                string filePath;
                try
                {
                    var bm = ByteArrayToImage(image);
                    if (!Directory.Exists(root)) // checking if upload directory exists or not
                    {
                        Directory.CreateDirectory(root);
                    }
                    filePath = $"{ToUrlSlug($"IMG-{GetUnixEpochMethod(DateTime.Now)}-{fileName}")}.{ImageFormat.Jpeg}";
                    var filePathUpdated = Path.Combine(root, filePath);
                    bm.Save(filePathUpdated, ImageFormat.Jpeg);
                    bm.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return localPath + "/Uploads/" + filePath;
            }
    
    protected Image ByteArrayToImage(byte[] byteArrayIn)
            {
                var converter = new ImageConverter();
                var img = (Image)converter.ConvertFrom(byteArrayIn);
                return img;
            }
    
    /// <summary>
            /// Renaming Files name according to current system time
            /// </summary>
            /// <param name="dateTime"></param>
            /// <returns></returns>
            protected double GetUnixEpochMethod(DateTime dateTime)
            {
                var unixTime = dateTime.ToUniversalTime() -
                               new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    
                return unixTime.TotalSeconds;
            }
    
            protected string ToUrlSlug(string value)
            {
                //First to lower case 
                value = value.ToLowerInvariant();
                //Remove all accents
                var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
                value = Encoding.ASCII.GetString(bytes);
                //Replace spaces 
                value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);
                //Remove invalid chars 
                value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);
                //Trim dashes from end 
                value = value.Trim('-', '_');
                //Replace double occurences of - or \_ 
                value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);
                return value;
            }
    
        }
