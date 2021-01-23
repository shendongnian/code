    interface IBike {
        void Pedal();
    }
    class Bike : IBike {
        public void Pedal() {
            Console.WriteLine("Moving my vehicle with my body");
        }
    }
    interface IMotorcycle {
        void Accelerate();
    }
    class Motorcycle : IMotorcycle {
        public virtual void Accelerate() {
            Console.WriteLine("Moving my vehicle with a hydrocarbon fuel engine");
        }
    }
    class ElectricBike : Motorcycle, IBike {
        bool _isAccelerating = false;
        public override void Accelerate() {
            _isAccelerating = true;
            Console.WriteLine("Moving my vehicle with a electric engine");
        }
        public void Pedal() {
            if (!_isAccelerating)
                Console.WriteLine("Moving my vehicle with my body");
            else
                Console.WriteLine("Occupying my body with senseless effort, for my vehicle is already moving"); 
        }        
    }
    class MovingMyVehicle {
        static void Main() {
            IMotorcycle motorBike = new Motorcycle();
            //That is expected, as IMotorcycle can Accelerate.
            motorBike.Accelerate();
            IBike newBike = new ElectricBike();
            //That too is expected, as IBike can Pedal.
            newBike.Pedal();
            //Now that´s something new, as IBike cannot Accelerate, 
            //but the the ElectricBike adapter can, as it implements both interfaces.
            (newBike as IMotorcycle).Accelerate();
            Console.Read();
        }
    }
