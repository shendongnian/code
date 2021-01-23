    List<Vehicle> Vehicles = new List<Vehicle>();
    Vehicle v = new Vehicle();
    v.Tires.Add(new Tire(16));
    Vehicles.Add(v);
    VehiTruck tr = new VehiTruck();
    tr.TireTrucks.Add(new TireTruck(20, 20));
    tr.TireTrucks.Add(new TireTruck(21, 21));
    Debug.WriteLine(tr.TireTrucks.Count());
    Vehicles.Add(tr);
    foreach (Vehicle vv in Vehicles)
    {
        if (vv is VehiTruck)
        {
            VehiTruck vt = (VehiTruck)vv;
            Debug.WriteLine(vt.TireTrucks.Count);
            Debug.WriteLine(vt.TireTrucks[0].Size);
        }
        else
        {
            Debug.WriteLine(vv.Tires.Count);
            Debug.WriteLine(vv.Tires[0].Size);
        }
    }
    public class Tire
    {
        public int Size { get; set; }
        public Tire(int size)
        {
            Size = size;
        }
    }
    public class TireTruck : Tire
    {
        public int Rating { get; set; }
        public TireTruck(int size, int rating) : base(size)
        {
            Rating = rating;
        }
    }
    public class Vehicle
    {
        public List<Tire> Tires { get; } = new List<Tire>();
        public Vehicle() { }
        public Vehicle(Vehicle v) { }
    }
    public class VehiTruck : Vehicle
    {
        public List<TireTruck> TireTrucks { get; } = new List<TireTruck>();
        public VehiTruck() { }
        public VehiTruck(Vehicle v) : base(v)
        { }
    }
