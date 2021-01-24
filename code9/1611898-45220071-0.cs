    public class TruckToVehicleAdapter : IVehicle
    {
        private readonly Truck _truck;
        
        public TruckToVehicleAdapter(Truck truck)
        {
            _truck = truck;
        }
        public decimal Height { get { return _truck.WhateverHeightPropertyThisHas; } }
    }
