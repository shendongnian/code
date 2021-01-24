    ArrayList poles;
    if (dictionary.ContainsKey(floor))
    {
       poles = dictionary[floor];
    }
    
    if(poles!=null)
    {
       for (int i = 0; i <= 4; i++)
       {
          poles.Add(pole);
       }
    }
