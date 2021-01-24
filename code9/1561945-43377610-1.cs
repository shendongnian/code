    [HttpPost]
    public void NewItems(List<ItemsViewModel> newItems) 
    {
         foreach(var item in newItems){
             item.user... // And so on.
         }
    }
