     // You have to switch to long from UInt32 since... 
     Dictionary<string, long> cars = new Dictionary<string, long>();
    
     cars.Add("Vehicle1", 4294967295L);
     cars.Add("Vehicle2", 6329496762L); // ... this value is greater than UInt32.MaxValue
    
     // var: you have no need to put such a long declaration as KeyValuePair<string, long>
     foreach (var pair in cars)
     {
         string vehiclename = pair.Key; 
         long vehicledata = pair.Value;   
     }
