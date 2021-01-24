    var properties = yourInstance.GetType().GetProperties();
    int count = 0;
    for(int i = 0; i < props.Length; i++)
    {
        if(props[i] != null)
        {
            count++;
        }
    }
    
    if(count == 0)
    {
        ... // Handle
    }
    
    ... // Create record.
