     object[] RA= {"Ram",123,122};
    for(int i = 0;i< RA.Length;i++)
    {
      if(RA[i].GetType() == typeof(string))
      { 
         Console.WriteLine("string");
      }
      else
      {
         Console.WriteLine("int");
      }
    }
