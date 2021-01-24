    private class RoomKitchenPair
        {
            public int RoomId { get; set; }
            public int KitchenId { get; set; }
        }
    var result = (from r in Room
             join k in Kitchen on r.IdKitchen equals k.Id
             where (r.Id == myIDPassedAsParameter)
             select new RoomKitchenPair { RoomId= r.Id, KitchenId = k.Id})
    foreach (var r in result)
    {
        Console.WriteLine(r.RoomId + " - " + r.KitchenId );
    }
