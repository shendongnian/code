    public string Category {
        get {
            if (!localized) {
                localized = true;
                string localizedValue = GetLocalizedString(categoryValue);
                if (localizedValue != null) {
                    categoryValue = localizedValue;
                }
            }
            return categoryValue;
        }
    }
    protected virtual string GetLocalizedString(string value) {
    #if !SILVERLIGHT
        return (string)SR.GetObject("PropertyCategory" + value);
    #else
        bool usedFallback;
        string localizedString = SR.GetString("PropertyCategory" + value, out usedFallback);
        if (usedFallback) {
            return null;
        }
        return localizedString;
    #endif
    }
