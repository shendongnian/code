       public class CustomUrlAttribute : ValidationAttribute
        {
            public CustomUrlAttribute()
            {
    
            }
    
            private bool IsUrlValid(string url)
            {
                string pattern =
                    @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
                Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return reg.IsMatch(url);
            }
    
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    ErrorMessage = "Field Must be required";
                    return false;
                }
                string strValue = value as string;
    
                if (!IsUrlValid(strValue))
                {
                    ErrorMessage = "Invalid URL";
                    return false;
                }
    
                return true;
            }
        }
  
     public class ContactModel
        {
            [DisplayName("Event URL")]
            [CustomUrlAttribute()]           
            public string EventURL { get; set; }    
        }
