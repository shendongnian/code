    private string GetStringOnContent(string content, string searchText)
            {
                string findValue = string.Empty;
                int strIndex = content.IndexOf(searchText);
                if(strIndex > 0 )
                {
                    findValue = content.Substring(strIndex, searchText.Length );
                }
    
                return findValue;
            }    
        
    var findStr = GetStringOnContent("This is content that has John as a part of content", "John");
