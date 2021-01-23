    private bool decodeValue(int id,ref object item, string code)
    {
    
        if(!TypeDescriptor.GetConverter(item).CanConvertFrom(typeof(string)))
        {
            errorThrow (id + 2);
            return false;
        }
        try
        {
            item = TypeDescriptor.GetConverter(item).ConvertFromString(code);
        }
        catch 
        {
            errorThrow (id + 2);
            return false;
        }
    
        return true;
    }
    
    private bool decodeValues(string[] code, int id, params object[] items)
    {
        for (int i = 0; i < items.Length; i++) 
        {
            //in this part i cant find the correct syntax
            if(decodeValue(id, ref items[i], code[i+2]))
            {
    
            }
        }
    
        return false;
    }
