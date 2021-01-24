        private bool SearchStringByIndexOf(string content, string searchText)
                {
                    bool isMatch = false;
                    int isContains = content.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase);
        
                    if (isContains == 0 && content.Replace(searchText, "").Length == 0)
                    {
                        isMatch = true;
                    }
        
                    return isMatch;
                }
    
    
    // use method this code
    var isEqual = SearchStringByIndexOf("Johnson","John");
