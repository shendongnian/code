    using System;
    using System.Collections.Generic;
    
    namespace Dirty
    {
        class Program
        {
            static void Main()
            {
                var vehicles = new List<Vehicle>();
    
                var bike = new Bicycle();
                var motorbike = new Motorbike();
                var car = new Car();
    
                vehicles.Add(bike);
                vehicles.Add(motorbike);
                vehicles.Add(car);
    
                foreach (var v in vehicles)
                {
                    if (v.CleanWindows())
                    {
                        Console.WriteLine("{0}", v);
                    }
                }
    
                Console.ReadKey();
            }
        }
    
        class Vehicle
        {
            public virtual bool CleanWindows()
            {
                return false;
            }
        }
    
        class Bicycle : Vehicle
        {
    
        }
    
        class Motorbike : Vehicle
        {
    
        }
    
        class Car : Vehicle
        {
            public override bool CleanWindows()
            {
                return true;
            }
        }
    }
