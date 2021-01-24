    public static Model ToModel(this PTS_MODELS model)
    {
        return new Model()
        {
            ModelID = model.ModelID,
            Name = model.Name,
            Make = new Make()
            {
                MakeID = model.PTS_MAKES.MakeID,
                Name = model.PTS_MAKES.Name
            }
        };
    }
    public static IEnumerable<CustomerDevice> ToCustomerDevice(this IQueryable<PTT_CUSTOMER_DEVICES> devices)
    {
        return devices
        	.Include(d => d.PTS_MODELS.PTS_MAKES)
        	.AsEnumerable() // Evaulate everything that follows in memory
        	.Select(d => new CustomerDevice
	        {
	            customerAssetTag = d.CustomerAssetTag,
	            customerDeviceID = d.CustomerDeviceID,
	            Model = d.PTS_MODELS.ToModel()
	        });
    }
