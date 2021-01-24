    interface IVehicle
    {
    	int GetNumberOfWheels();
    	int GetNumberOfDoors();
    }
    
    interface ICheeseContainer
    {
    	int GetNumberOfWheels();
    	int GetNumberOfWedges();
    }
    
    class CheeseDeliveryTruck : IVehicle, ICheeseContainer
    {
    	// Object has to be able to return the number of wheels on the truck
        // when used as an IVehicle.
    	// Object has to be able to return the number of cheeses in the back of
        // the truck which are packaged as wheels when used as an ICheeseContainer.
    }
