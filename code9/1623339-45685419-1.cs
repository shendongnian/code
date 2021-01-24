    public abstract class Gear
    {
        public static List<Gear> gears = new List<Gear>();
        public Gear()
        {
            gears.Add(this);
        }
        public static void Update()
        {
            foreach (var gear in gears)
                gear._Update();
        }
        protected abstract void _Update();
    }
   
    public sealed class Gear1 :  Gear
    {
        protected override void _Update()
        {
            //do stuff
        }
    }
    public sealed class Gear2 : Gear
    {
        protected override void _Update()
        {
            //do stuff
        }
    }
    public sealed class Gear3 : Gear
    {
        protected override void _Update()
        {
            //do stuff
        }
    }
    public static void Main(string[] args)
    {
        var timer = 
         new Timer(o => Gear.Update(), null, 0, SOME_INTERVAL);                       
    }
