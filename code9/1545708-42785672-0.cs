    class Program
    {
        static void Main(string[] args)
        {
            var games = new Tuple<string, Nullable<double>>[] 
                  { new Tuple<string, Nullable<double>>("Fallout 3:    $", 13.95),
                    new Tuple<string, Nullable<double>>("GTA V:    $", 45.95),
                    new Tuple<string, Nullable<double>>("Rocket League:    $", 19.95) };
    
            Array.Resize(ref games, 4);
            games[3] = new Tuple<string,double?>("Test", 19.95);
        }
    }
