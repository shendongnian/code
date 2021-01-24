    List<Room> rooms = GetSelectedRooms(); //example
    bool samePolicy = false;
    var firstRoom = rooms.FirstOrDefault();
    if (firstRoom != null)
    {
    	samePolicy = rooms.All(r => r.GuaranteePolicy == firstRoom.GuaranteePolicy);
    }
    //Attach samePolicy onto ViewModel or ViewBag so you can use it inside Razor view
    
