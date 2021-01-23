    public abstract class Feature : IComparable
    {
        internal float _cost;
        public abstract void Install(Car car);
    }
    public class FuelInjection : Feature
    {
        public override void Install(Car car)
        {
            car.price += this._cost;
        }
    }
