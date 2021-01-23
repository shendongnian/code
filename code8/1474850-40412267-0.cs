    [HttpGet]
    public PartialViewResult Details(int id)
    {
        // sample code to get the vehicle
        var model = db.Vehicles.FirstOrDefault(x => x.VehicleID == id);
        if (model == null)
        {
            // refer notes below
        }
        return PartialView("PartialVehicleDetails", model);
    }
