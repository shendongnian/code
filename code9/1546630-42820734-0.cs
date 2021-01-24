    var list = myobject as List<int>();
    if(list == null)
    {
        // The cast failed. 
        // If the method's return type is void change the following to return;
        return null; 
    }
    for (int i = 0; i < list.Count; i++)
    {
        string str = list[i].toString();
    }
