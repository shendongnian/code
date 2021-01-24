    public class Program
    {
        public static string val; // THIS IS AN ERROR?
        static void Main(string[] args)
        {
            // get parameter value
            if (args.Length>0)
            {
               Program.val = args[0];
