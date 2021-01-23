    var list1= new List<string>(); 
      // manipulate list1
     var list2= new List<string>();
        // manipulate list2
     var MainList= new List<string>();
     MainList.AddRange(list1);
     MainList.AddRange(list2);
     MainList.ForEach(t=>{
      // do your action
     });
