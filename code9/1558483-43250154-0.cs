    static void Main(string[] args)
    {
        Random rnd = new Random();
        byte[] distortion = new byte[8];
        long[] b = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] a = { 100, 200, 300, 400, 500, 600, 700, 800 };
        for (int count = 1; count <= 100000; count++)
        {
            bool display = count % 100 == 0;
            if (display)
            {
                Console.Write(count + "  ");
            }
            rnd.NextBytes(distortion);
            for (int i = 0; i < distortion.Length; i++)
            {
                int distortedValue = a[i] + 127 - (int)(distortion[i]);
                b[i] += distortedValue;
                if (display)
                {
                    Console.Write(((int)((double)b[i] / count + 0.5)).ToString() + " ");
                }
            }
            if (display)
            {
                Console.WriteLine();
            }
        }
        Console.ReadLine();
    }
