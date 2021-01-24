    public class Car
    {
        public int CylinderCount {get;set;}
        public double GasTankSize {get;set;}
        public double Weight {get;set;}
        public virtual string GetFormattedWeight()
        {
            return $"Your car's weight is {Weight}!"
        }
    }
    public class MonsterTruck : Car
    {
        public override string GetFormattedWeight()
        {
            return $"Your monster truck's weight is {Weight}!"
        }
    }
