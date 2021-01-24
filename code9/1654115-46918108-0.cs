    var status = "BUY";
    List<Object> newList = new List<Object>();
        foreach (var item in list.OrderBy(x=>x.Date)){
         if(item.Status == status){
              newList.Add(item);
              status = status == "BUY"?"SELL":"BUY";
         }
    }
