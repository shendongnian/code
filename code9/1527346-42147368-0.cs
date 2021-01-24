    private List<Vehicle> vehicleList;
    public double getVehiclePrice(int index){
        if(index >= 0 && index < vehicleList.Count){
            return vehicleList[index].price;
        }
    }
