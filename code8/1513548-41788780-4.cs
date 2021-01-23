        public virtual string ToString(string format, IFormatProvider formatProvider)
        {
            ...
            if (format.StartsWith("A"))
            {
                string url = format.Substring(1);
                return string.Format(formatProvider, "<a href='{0}{1}'>{2}</a>", url, WebUtility.UrlEncode(Id), WebUtility.HtmlDecode(Name));
            }
            ...
            return Name;
        }
        
