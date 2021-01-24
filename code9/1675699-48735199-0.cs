    //Removing obj from oldArray
    private static JArray RemoveValue(JArray oldArray, dynamic obj)
    {
        List<string> temp2 = oldArray.ToObject<List<string>>();
        temp2.Remove(obj); 
        return JArray.FromObject(temp2);
    }
