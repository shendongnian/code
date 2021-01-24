    RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
    foreach (var car in root.cars)
    {
    	var carProperties = car.GetType().GetProperties().Where(p => typeof(ICar).IsAssignableFrom(p.PropertyType));
    	foreach (var carType in carProperties)
    	{
    		var c = carType.GetValue(car);
    		if (c != null)
    		{
    			var colors = ((ICar)c).color;
    			//Do your thing...
    		}
    	}
    }
