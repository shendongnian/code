    using System;
    namespace StackOverflow_OOP
    {
        class Program
        {
            static void Main(string[] args)
            {
                Car car = new Car(VehicleFuelType.Petrol, 20);
                Console.Out.WriteLine("Vehicle Type: {0}", car.Type);
                Van van = new Van(VehicleFuelType.Diesel, 40);
                Console.Out.WriteLine("Vehicle Type: {0}", van.Type);
                Console.ReadLine();
            }
        }
        public enum VehicleFuelType
        {
            Petrol,
            Diesel,
            LPG
        }
        public abstract class Vehicle
        {
            public VehicleFuelType FuelType { get; }
            public int TankCap { get; }
            public double FuelInTank { get; }
            public string Type { get { return this.GetType().Name; } }
            public Vehicle(VehicleFuelType fuelType, int tankCap, double fuelInTank)
            {
                FuelType = fuelType;
                TankCap = tankCap;
                FuelInTank = fuelInTank;
            }
        }
        public class Car : Vehicle
        {
            public Car(VehicleFuelType fuelType, double fuelInTank) : base(fuelType, 40, fuelInTank)
            {
            }
        }
        public class Van : Vehicle
        {
            public Van(VehicleFuelType fuelType, double fuelInTank) : base(fuelType, 80, fuelInTank)
            {
            }
        }
    }
