    public string ReplaceBRwithNewline(string txtVal)  
    {  
        string newText = "";  
        // Create Regex    
        System.Text.RegularExpressions.Regex regex =   
            new System.Text.RegularExpressions.Regex(@"(<br />|<br/>|</ br>|</br>)");  
        // Replace new line with <br/> tag    
        newText = regex.Replace(txtVal, "\r\n");  
        // Result    
        return newText;  
    }
