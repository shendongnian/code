     string retval = string.Empty;
        foreach (var property in pi)
            if (property.Name.ToLower().Equals(prop.ToLower()))
                {
                   retval = property.GetValue(prop).ToString();
                   break; //stop looping
                }
        
        return retval;
