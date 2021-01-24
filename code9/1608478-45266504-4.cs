    public static string GetProperty(this DirectoryEntry directoryEntry , string propertyName, int index = 0) {
        if (directoryEntry.Properties.Contains(propertyName) && index > -1 && index < directoryEntry.Properties[propertyName].Count) {
            return oDE.Properties[propertyName][index].ToString();
        } else {
            return string.Empty;
        }
    }
    public static string GetProperty(this Principal principal, string property) {
        var directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
        return directoryEntry.GetProperty(property);
    }
