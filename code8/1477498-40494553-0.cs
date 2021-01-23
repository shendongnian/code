    public string UrlReplace(string Url, string key, string value = "")
    {
        var replaceString = "{" + key + "}"; //get the string to replace
        
        //if the value is empty remove the slash
        if (string.IsNullOrEmpty(value))
        {
            //find the index of the replace string in the url
            var index = url.IndexOf(replaceString) + replaceString.Length;
            if (url[index] == '/')
            {
                url = url.Remove(index, 1); //if the character after the string is a slash, remove it
            }
        }
        return url.Replace(replaceString, value);  //replace the string with the value
    }
