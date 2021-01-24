    public class GenericType<T>
    {
        public virtual T Test0()
        {
            return default(T);
        }
        public virtual T this[int i]
        {
            get { return default(T); }
            set { }
        }
    }
    public class FloatType : GenericType<float>
    {
        public override float Test0()
        {
            return 0;
        }
        public override float this[int i]
        {
            get { return 0; }
            set {  }
        }
    }
    GenericType<float> nonOptimizedFloat = new GenericType<float>();
    var defVal = nonOptimizedFloat[3]; // will use the non-optimized version
            
    GenericType<float> optimizedFloat = new FloatType();
    defVal = optimizedFloat[3]; // will use the optimized version
