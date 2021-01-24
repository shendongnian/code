    public static string ToTitle(this string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                return string.Format(textInfo.ToTitleCase(data.ToLower()));
            }
            return data;
        }
