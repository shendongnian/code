    class MyGroup
    {
       public string Type => (Numbers?.Count??0) == 1? "Individual", "Continuous";
       public List<int> Numbers;
       public int Count => Numbers.Count;
    }
    List<MyGroup> LST = new List<MyGroup>();
    List<int> Temp = new List<int>();
    //Run from 0 to second-last element
    for(int i=0; i< arr.Length - 1; i++)
    {
      Temp.Add(arr[i]); //add this number to current group's list
      if(arr[i+1] != arr[i] + 1) //if next number is not adjacent
      {
        LST.Add(new MyGroup() { Numbers = Temp}); //create a new group
        Temp = new List<int>(); //and a new current list
      } 
    }
    //The above loop exits before the last item of the array.
    //Here we simply check if it is adjacent, we add it to the last group.
    //otherwise we create a new group for it.
    if(arr[arr.Length - 1] == arr[arr.Length - 2] + 1)
      LST.Last().Numbers.Add(arr.Last());
    else
      LST.Add(new MyGroup() { Numbers = new List<int>(new[] { arr.Last() }) });
