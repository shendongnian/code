    // numbers 1-100
    var list1 = Enumerable.Range(1,100).ToList();
            
    // 3 entries
    var list2 = new Dictionary<int,int[]>(){
            {1,new[]{21}},
            {10,new[]{21}},
            {21,new int[0]}
    };
    var result = list2.SelectMany(item => {
       if(!list1.Contains(item.Key))
           return Enumerable.Empty<int>();
       if(item.Value != null && item.Value.Length>0)
          return item.Value;
       return new[]{item.Key};
    }).Distinct();
