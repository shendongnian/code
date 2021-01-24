    public override String ToString() {
        return ToString(true);
    }
 
    internal virtual String ToString(bool urlencoded) {
        return ToString(urlencoded, null);
    }
 
    internal virtual String ToString(bool urlencoded, IDictionary excludeKeys) {
        int n = Count;
        if (n == 0)
            return String.Empty;
 
        StringBuilder s = new StringBuilder();
        String key, keyPrefix, item;
        bool ignoreViewStateKeys = (excludeKeys != null && excludeKeys[Page.ViewStateFieldPrefixID] != null);
 
        for (int i = 0; i < n; i++) {
            key = GetKey(i);
 
            // Review: improve this... Special case hack for __VIEWSTATE#
            if (ignoreViewStateKeys && key != null && key.StartsWith(Page.ViewStateFieldPrefixID, StringComparison.Ordinal)) continue;
            if (excludeKeys != null && key != null && excludeKeys[key] != null)
                continue;
            if (urlencoded)
                key = UrlEncodeForToString(key);
            keyPrefix = (key != null) ? (key + "=") : String.Empty;
 
            string[] values = GetValues(i);
 
            if (s.Length > 0)
                s.Append('&');
 
            if (values == null || values.Length == 0) {
                s.Append(keyPrefix);
            }
            else if (values.Length == 1) {
                s.Append(keyPrefix);
                item = values[0];
                if (urlencoded)
                    item = UrlEncodeForToString(item);
                s.Append(item);
            }
            else {
                for (int j = 0; j < values.Length; j++) {
                    if (j > 0)
                        s.Append('&');
                    s.Append(keyPrefix);
                    item = values[j];
                    if (urlencoded)
                        item = UrlEncodeForToString(item);
                    s.Append(item);
                }
            }
        }
 
        return s.ToString();
    }
