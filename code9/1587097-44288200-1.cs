        static void Main(string[] args)
        {
            int I = 0;
            int i = 0;
            List<Color> Colors1 = new List<Color>();
            List<Color> Colors2 = new List<Color>();
            while (i != 1000)
            {
                Colors1.Add(RandomColor());
                Colors2.Add(RandomColor());
                i++;
            }
            Stopwatch a = new Stopwatch();
            a.Start();
            while (I != 1000)
            {
                ColorChanged1(Colors1.ElementAt(I), Colors2.ElementAt(I));
                I++;
            }
            a.Stop();
            Console.WriteLine("ColorChanged1: " + a.Elapsed.ToString());
            a.Reset();
            a.Start();
            I = 0;
            while (I != 1000)
            {
                ColorChanged2(Colors1.ElementAt(I), Colors2.ElementAt(I));
                I++;
            }
            a.Stop();
            Console.WriteLine("ColorChanged2: " + a.Elapsed.ToString());
            a.Reset();
            a.Start();
            I = 0;
            while (I != 1000)
            {
                ColorChanged3(Colors1.ElementAt(I), Colors2.ElementAt(I));
                I++;
            }
            a.Stop();
            Console.WriteLine("ColorChanged3: " + a.Elapsed.ToString());
            Console.ReadLine();
        }
        static Color RandomColor()
        {
            Array values = Enum.GetValues(typeof(KnownColor));
            Random random = new Random();
            KnownColor rcolor = (KnownColor)values.GetValue(random.Next(values.Length));
            return Color.FromKnownColor(rcolor);
        }
        static bool ColorChanged1(Color a, Color b)
        {
            return a.ToArgb() != b.ToArgb();
        }
        static bool ColorChanged2(Color a, Color b)
        {
            return a != b;
        }
        static bool ColorChanged3(Color a, Color b)
        {
            return a.ToKnownColor() != b.ToKnownColor();
        }
