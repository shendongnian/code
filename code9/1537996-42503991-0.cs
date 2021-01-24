    private List<Vehicles> _vehicles;
    public List<Vehicles> Vehicles {
        get {
            if(_vehicles == null) {
                _vehicles = _repository.Set<Vehicles>().Where(e => e.VehicleType == VEHICLE_TYPE && e.Weight < CAR_MAX_WEIGHT);
            }
            return _vehicles;
        }
    }
