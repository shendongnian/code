    class MyGroup
    {
       public string Type => (Numbers?.Count??0) == 1? "Individual", "Continuous";
       public List<int> Numbers;
       public int Count => Numbers.Count;
    }
    List<MyGroup> LST = new List<MyGroup>();
    List<int> Temp = new List<int>();
    for(int i=0; i< arr.Length - 1; i++)
    {
      Temp.Add(arr[i]);
      if(arr[i+1] != arr[i] + 1)
      {
        LST.Add(new MyGroup() { Numbers = Temp});
        Temp = new List<int>();
      } 
    }
