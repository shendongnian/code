    string freeServices = "1,7,13,21";
    List<int> selectedServices = booking.SelectedServices.Select(x => x.ServiceID).ToList();
    var splittedFreeServices = freeServices.Split(',').Select(k => int.Parse(k));
    var result = selectedServices.All(x => splittedFreeServices.Contains(x));
    if (result) //booking.SelectedServices contains all elements of freeServices as integer
    {
    			
    }
