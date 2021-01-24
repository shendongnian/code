    public class Unicorn
    {
        static Dictionary<Attitude, Func<string>> RainbowByAttitude =
            new Dictionary<Attitude, Func<string>>()
            {
                [Attitude.Bad] = new Func<string>(() => "dark rainbow"),
                [Attitude.Good] = new Func<string>(()=>"light rainbow")
                    
            };
        public string Horn { get; set; }
        public enum Attitude
        {
            Good,Bad
        }
        public Attitude attitude;
        public Unicorn(Attitude attitude)
        {
            this.attitude = attitude;
        }
        public string Rainbow() => RainbowByAttitude[attitude].Invoke();
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Unicorn unicorn;
            unicorn = new Unicorn(Unicorn.Attitude.Bad);
            Console.WriteLine(unicorn.Rainbow());
            unicorn.attitude = Unicorn.Attitude.Good;
            Console.WriteLine(unicorn.Rainbow());
        }
    }
