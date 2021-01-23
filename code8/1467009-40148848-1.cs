    Dictionary<Object, int> output = new Dictionary<Object, int>();
    int count;
    if(output.TryGetValue(keyObject, out count))
    {
         output[keyObject] = count + 1;
    }
    else
    {
         output.Add(keyObject, 1);
    }
