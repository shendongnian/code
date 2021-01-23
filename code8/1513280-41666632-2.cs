    public class MyTextFile
    {
        public List<Array> Commands = new List<Array>();
        public void EnumerateCommands()
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                foreach (var c in Commands[i])
                    Console.Write(c + " ");
                Console.WriteLine();
            }
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
                    if (count >= 3)
                    {
                        object[] Arguments = line.Split(',');
                        tf.Commands.Add(Arguments);
                    }
                }
            }
            tf.EnumerateCommands();
            Console.ReadLine();
        }
	}
