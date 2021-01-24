    var vehicle = _vehilceRepository.GetSingle(c => c.vehicleId == _vID);
    var clients = _clientRepository.GetList(c => c.OrganisationID == OrganisationId);
    return clients.SelectMany(client => _LocationRepository.GetList(
                    c => c.ClientID == client.ClientID))
           .Any(location => location.LocationId == vehicle.LocationID);
?
            
