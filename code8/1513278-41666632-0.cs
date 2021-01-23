    public class MyTextFile
    {
        public List<string> Commands = new List<string>();
        public void EnumerateCommands()
        {
            foreach (var c in Commands)
                Console.WriteLine(c);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string line = "";
            int count = 0;
            MyTextFile tf = new MyTextFile();
            using (StreamReader sr = new StreamReader(@"path"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    count += 1;
                    if (count == 3)
                    {
                        string[] lineThree = line.Split(',');
                        foreach (var l in lineThree)
                            tf.Commands.Add(l);
                    }
                }
            }
            tf.EnumerateCommands();
            Console.ReadLine();
        }
	}
