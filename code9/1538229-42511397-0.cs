    string[] list=numbers.Trim().Split(',');
    List<int> theList=new List<int>();
    foreach (string item in list)
    {
      int result;
      if (int.TryParse(out result)
      {
           theList.Add(result);
      }
    }
