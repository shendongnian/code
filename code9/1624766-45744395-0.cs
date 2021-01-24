    static class Program
    {
        static void Main(string[] args)
        {
            var b747_100 = new B747("100", false, 333400);
            var b747_300 = new B747("800", false, 439985);
            var b747_300sp = new B747("300sp", true, 287500);
            var factory = new AirplaneFactory<B747>(b747_100, b747_300, b747_300sp);
            var a_b747_300sp = factory.Make("300sp");
            // makes a cargo version of the B474
            var a_b747_800 = factory.Make("800");
            // makes a passenger version of the B474
            var a_b747_400 = factory.Make("400");
            // makes nothing. No prototype for 400 series
            var copy_of_a_b747_800 = a_b747_800.Clone();
        }
    }
    /// <summary>
    /// Base class. Each airplane has a model moniker.
    /// </summary>
    public abstract class Airplane
    {
        protected Airplane(string model, int engineCount)
        {
            this.Model=model;
            this.EngineCount=engineCount;
        }
        /// <summary>
        /// Create a new airplane with properties from another (Copy constructor).
        /// </summary>
        /// <param name="other"></param>
        protected Airplane(Airplane other)
        {
            this.Model=other.Model;
            this.EngineCount=other.EngineCount;
        }
        public string Model { get; }
        public int EngineCount { get; }
        public abstract float Mass { get; }
    }
    public class F16 : Airplane, ICloneable
    {
        public F16(F16 prototype) : base(prototype)
        {
            this.Mass=prototype.Mass;
        }
        public F16(string model, float mass) : base(model, 1)
        {
            this.Mass=mass;
        }
        public override float Mass { get; }
        #region ICloneable Members
        public F16 Clone() { return new F16(this); }
        object ICloneable.Clone()
        {
            return Clone();
        }   
        #endregion
    }
    public class B747 : Airplane, ICloneable
    {
        public B747(string model, bool isCargo, float mass) : base(model, 4)
        {
            this.IsCargo=isCargo;
            this.Mass=mass;
        }
        public B747(B747 prototype) : base(prototype)
        {
            this.IsCargo=prototype.IsCargo;
            this.Mass=prototype.Mass;
        }
        public bool IsCargo { get; }
        public override float Mass { get; }
        #region ICloneable Members
        public B747 Clone() { return new B747(this); }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
    public class AirplaneFactory<T> where T : Airplane
    {
        /// <summary>
        /// Use reflection to get the copy constructor for each type 'T'
        /// </summary>
        static ConstructorInfo ctor = typeof(T).GetConstructor(new[] { typeof(T) });
        /// <summary>
        /// Hold a table of monikers and planes of type T
        /// </summary>
        readonly IDictionary<string, T> models;
        /// <summary>
        /// Create a factor with some built in plane models
        /// </summary>
        /// <param name="airplaneModels">The models that the factory can make</param>
        public AirplaneFactory(params T[] airplaneModels)
        {
            this.models=airplaneModels.ToDictionary((x) => x.Model);
        }
        /// <summary>
        /// Public API exposes a readonly table so users can't add whatever planes they want.
        /// </summary>
        public IReadOnlyDictionary<string, T> Models { get { return models as IReadOnlyDictionary<string, T>; } }
        /// <summary>
        /// Add a plan for new planes. If the model already exists then do nothing
        /// </summary>
        /// <param name="prototype">The plane prototype to implement</param>
        /// <returns>True if the plans are added</returns>
        public bool ImplementNewPlans(T prototype)
        {
            if(!models.ContainsKey(prototype.Model))
            {
                models.Add(prototype.Model, prototype);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Create a new plane from the prototype stored in 'Models'.
        /// </summary>
        /// <param name="model">The model moniker</param>
        /// <returns>A new plane if the have a prototype, null otherwise</returns>
        public T Make(string model)
        {
            if(models.ContainsKey(model))
            {
                return ctor.Invoke(new object[] { models[model] }) as T;
            }
            return null;
        }
    }
