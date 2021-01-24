    public class ClassThatDependsOnThreeThings
    {
        private readonly IThingOne _thingOne;
        private readonly IThingTwo _thingTwo;
        private readonly IThingThree _thingThree;
        public ClassThatDependsOnThreeThings(IThingOne thingOne, IThingTwo thingTwo, IThingThree thingThree)
        {
            _thingOne = thingOne;
            _thingTwo = thingTwo;
            _thingThree = thingThree;
        }
    }
    public class ThingOne : IThingOne
    {
        private readonly IThingFour _thingFour;
        private readonly IThingFive _thingFive;
      
        public ThingOne(IThingFour thingFour, IThingFive thingFive)
        {
            _thingFour = thingFour;
            _thingFive = thingFive;
        }
    }
    public class ThingTwo : IThingTwo
    {
        private readonly IThingThree _thingThree;
        private readonly IThingSix _thingSix;
        public ThingTwo(IThingThree thingThree, IThingSix thingSix)
        {
            _thingThree = thingThree;
            _thingSix = thingSix;
        }
    }
    public class ThingThree : IThingThree
    {
        private readonly string _connectionString;
        public ThingThree(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
