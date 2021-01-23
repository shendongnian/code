    public class ArcherFactory : UnitFactory<ArcherType, Archer>
    {
        public ArcherFactory()
        {
            this.Register(ArcherType.Longbowman, () => new Archer(...));
            this.Register(ArcherType.Crossbowman, () => new Archer(...));
        }
    }
    public abstract class UnitFactory<TType, TUnit>
    {
        private readonly Dictionary<TType, Func<TUnit>> factoryMethods = new Dictionary<TType, Func<TUnit>>();
        protected void Register(TType type, Func<TUnit> constructorFuc)
        {
            // perform some sanity checks
            this.factoryMethods.Add(type, constructorFuc);
        }
        public TUnit GetUnit(TType type)
        {
            // perform some sanity checks
            return this.factoryMethods[type]();
        }
    }
