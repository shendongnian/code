     Dictionary<string, UInt32> cars = new Dictionary<string, UInt32>();
    
     cars.Add("Vehicle1", 4294967295);
     cars.Add("Vehicle2", 6329496762);
    
     foreach (KeyValuePair<string, UInt32> pair in cars)
     {
         string vehiclename = pair.Key; 
         UInt32 vehicledata = pair.Value;   
     }
