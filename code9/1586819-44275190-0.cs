    public string replaceString(string value)
    {
        string newValue;
        string findValue;
        string replaceValue;
        findValue = textBox1.Text;
        replaceValue = textBox2.Text;
    
        if(value.StartsWith(findValue))
            newValue = value.Replace(findValue, replaceValue);
        else
            newValue = value;
        
        return newValue;
    }
