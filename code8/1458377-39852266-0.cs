    public class ArcherFactory : UnitFactory<ArcherType, Archer>
    {
        private static Archer _baseLongbowman = ....;
        private static Archer _baseCrossbowman = ....;
        public override Archer GetUnit(ArcherType type)
        {
            switch (type)
            {
                case ArcherType.Crossbowman:
                    return  _baseCrossbowman.Clone(...);
                default:
                    return  _baseLongbowman.Clone(...);
            }
        }
    }
