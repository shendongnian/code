    public interface IPump
    {
        void Refuel(Vehicle vehicle)
    }
    
    public class SlowRefuelPump
    {
        public void Refuel(Vehicle vehicle)
        {
           //slow refuelling
        }
    }
    
    public class FastRefuelPump
    {
        public void Refuel(Vehicle vehicle)
        {
           //fast refuelling
        }
    }
