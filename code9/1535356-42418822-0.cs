     var tupleList = new List<Tuple<string, string>>();
     for (int i = 0; i < data.Count; i++)
     {
         for (int j = i + 1; j < data.Count; j++)
         {
             tupleList.Add(new Tuple<string, string>(data[i], data[j]));
         }
     }
