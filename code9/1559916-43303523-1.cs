    using System;
    namespace StackOverflow_OOP
    {
        class Program
        {
            // Randomness removed: you want a driver to **consistently** pass or fail.
            static void Main(string[] args)
            {
                Car car = new Car(VehicleFuelType.Petrol, 20);
                // The first arg specifies format/placement of the second
                Console.Out.WriteLine("Vehicle Type: {0}", car.Type);
                // In background, uses String.Format()
                // See https://msdn.microsoft.com/en-us/library/system.string.format(v=vs.110).aspx
                Van van = new Van(VehicleFuelType.Diesel, 40);
                Console.Out.WriteLine("Vehicle Type: {0}", van.Type);
                Console.ReadLine();
            }
        }
        // A string that only takes a small number of values is called an enumeration
        // See https://msdn.microsoft.com/en-us/library/sbbt4032.aspx
        public enum VehicleFuelType
        {
            Petrol,
            Diesel,
            LPG
        }
        // Vehicle is clearly abstract in this context, while Car & Van are concrete.
        // See explaination after code.
        public abstract class Vehicle
        {
            public VehicleFuelType FuelType { get; }
            public int TankCap { get; }
            public double FuelInTank { get; private set; }
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
