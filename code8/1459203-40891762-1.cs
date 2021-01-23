    UserPrincipal user = new UserPrincipal(principal.Context);
    if (user == null) return false;
    DirectoryEntry directoryEntry = principal.GetUnderlyingObject() as DirectoryEntry;
    string title = "";
    if (directoryEntry.Properties.Contains("title"))
    {
        title = directoryEntry.Properties["title"].Value.ToString();
    }
    return title == "Comparison Value" | (title == "" || title == null);
