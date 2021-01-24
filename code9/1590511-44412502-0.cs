    public class Master
    {
        public static List<Master> data = new List<Master>();
    
        public static void Coll(Master master)
        {        
            data.Add(master);
            data.ForEach(Console.WriteLine);
        }
    }
