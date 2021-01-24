      public static readonly string[] _validExtensions = { "jpg", "bmp", "gif", "png", "jpeg","tiff","raw","psd" };
        public static bool IsImageExtension(string email)
        {
            bool isContainsImageExt = false;           
               
                MailAddress addr = new MailAddress(email);
                string username = addr.User;
                if (!string.IsNullOrEmpty(username) && username.Contains('.'))
                {
                    String[] parts = username.Split(new[] { '.' });
                    if(!string.IsNullOrEmpty(parts[0]) && !string.IsNullOrEmpty(parts[1]))
                    {
                        if(_validExtensions.Contains(parts[1].ToLower()) && (parts[0].ToLower().Contains("image")))
                        {
                             isContainsImageExt = true;
                        }
                    }
                }
           
            return isContainsImageExt;
        }
