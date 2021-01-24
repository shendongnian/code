    class Program
    {
        static bool running = true;
        static void Main(string[] args)
        {
            Thread t = new Thread(Keyboard);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            Thread t1 = new Thread(Print);
            t1.Start();
        }
        static void Print()
        {
            TypeLine("hello world");
        }
        static void TypeLine(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                if (running)
                {
                    System.Threading.Thread.Sleep(40);
                }
            }
            Console.Write("\n");
        }
        static void Keyboard()
        {
            while (running)
            {
                if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.LeftShift))
                {
                    running = false;
                }
            }
        }
    }
