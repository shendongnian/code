    var status = "BUY";
    List<Transaction> newList = new List<Transaction>();
        foreach (var item in list.OrderBy(x=>x.Date)){
         if(item.Status == status){
              newList.Add(item);
              status = status == "BUY"?"SELL":"BUY";
         }
    }
