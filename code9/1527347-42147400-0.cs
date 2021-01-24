	List<Vehicle> vehicleList { get; set; }
	
	//Get the price of the vehicle with parameter ID.
	public double GetPriceVehicle(int ID)
	{
		var result = vehicleList.Where(x => x.ID == ID).FirstOrDefault();
		if (result == null) 
		{
			throw new NotImplementedException(String.Format("Vehicle with ID={0} was not found", ID)); //todo: put in the logic you want for when no vehicle has the given id
		}
		return result.Price;
	}
