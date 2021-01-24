        static void Main(string[] args)
        {
            var size = GetScreenSize();
            Console.WriteLine(size.Length + " x " + size.Width);
            Console.ReadLine();
        }
        static Size GetScreenSize()
        {
            return new Size(GetSystemMetrics(0), GetSystemMetrics(1));
        }
        struct Size
        {
            public Size(int l, int w)
            {
                Length = l;
                Width = w;
            }
            public int Length { get; set; }
            public int Width { get; set; }
        }
        [DllImport("User32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetSystemMetrics(int nIndex);
