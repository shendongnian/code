      ObservableCollection<Test> objWithOutEmpty;
     foreach(var item in objWithEmpty)
       {
            if(item.Name !=null)
               {
                      objWithOutEmpty.Add(new Test(){item.Name});
               }
       };
