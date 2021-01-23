    PropertyInfo pi = typeof(Vehicles).GetProperty(vehVariant);
    var services = context.Vehicles.ToList();
    
    services = services.Where(item => pi.GetValue(item).ToString().Trim() == "Y").ToList();
 
