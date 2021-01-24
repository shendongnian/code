        static void Main(string[] args)
        {
            var s = "This is a printing test!";
            var f = new Font("Arial", 16);
            var w = 100d;
            Console.WriteLine(BreakIntoLines(s, w, f));
        }
        public static string BreakIntoLines(string s, double w, Font f)
        {
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var sb = new StringBuilder();
                var pw = 0d;
                foreach (var c in s.ToArray())
                {
                    var lw = Math.Floor(g.MeasureString(sb.Append(c).ToString(), f).Width / w);
                    if (lw != pw)
                    {
                        sb.Append(Environment.NewLine);
                        pw = lw;
                    }
                }
                return sb.ToString();
            }
        }
