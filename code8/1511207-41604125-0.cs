    public IEnumerable<OrderUpdate> GetList()
    {
       var validOrderTypes = new[] {1, 2, 3, 4};
       var UpdateList = new List<OrderUpdate>();
       // TODO: fill the list
 
       return UpdateList
         .Where(u => validOrderTypes.Contains(u.OrderType))
         .OrderBy(u => u.TrackId);
    }
