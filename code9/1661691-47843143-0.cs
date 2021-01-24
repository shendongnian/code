    public string ClearnUrl(string title)
            {
                string cleanTitle = title.ToLower().Replace(" ", "-");
                //Removes invalid character like .,-_ etc
                cleanTitle = Regex.Replace(cleanTitle, @"[^a-zA-Z0-9\/_|+ -]", "");
                cleanTitle = cleanTitle.Replace("/", "");
                return cleanTitle;
            }
