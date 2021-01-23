    abstract class Model<T>
         where T: Model<T>
    {
        public abstract T Clone();
    }
    class CarModel : Model<CarModel>
    {
        public override CarModel Clone()
        {
            return ...
        }
    }
