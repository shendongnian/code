    var listA = GetListA();
    var listB = GetListB();
    var max =  listA.Where(x=>listB.Any(s=>s.Match(x)).ToList().Count();
    //mathPairList is 2 dimensions Array which holds [listAitem, listBitem]
    Object[,] matchPairList= new Object[max, 2];
    int row = 0;
    foreach(var listAitem in listA)
    {
      var listBitem= listB.Where(s=>s.Match(listAitem)).FirstOrDefault().;
      if (match != null)
      {
          matchPairList[row,0] = listAitem;
          matchPairList[row,1] = listBitem; 
          row++;
      }
    }
