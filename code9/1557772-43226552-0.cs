    MakeModelTypeCode toBeSelected;
    
    var vehicleMakeList = vehicleViewModel.AvailableMakeModels
                .Select(s =>
                    new SelectListItem
                    {
                        Selected = s.MakeModelTypeCode == toBeSelected,
                        Text = s.MakeDescription,
                        Value = s.MakeModelTypeCode
                    });
