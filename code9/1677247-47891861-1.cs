    public static class MyConsole
    {
        public static void Test()
        {
            MyConsole.Columns(10, 40, 60)
                .Write("foo", "bar", "baz")
                .Write("LOL", "WUT", "BBQ")
                .Write("HA", "ha", "ha");
            var cols = MyConsole.Columns(10, 40, 30);
            cols.Write("Mary", "Had", "a");
            cols.Write("Little", "lamb", "it's");
        }
        public static ColumnWriter Columns(params int[] widths) => new ColumnWriter(widths);
        public class ColumnWriter
        {
            public ColumnWriter(int[] widths)
            {
                _widths = widths;
            }
            private int[] _widths;
            public ColumnWriter Write(params object[] args)
            {
                var count = Math.Min(_widths.Length, args.Length);
                for (int idx = 0; idx < count; ++idx)
                {
                    var fmt = "{0," + _widths[idx] + "}";
                    Console.Write(fmt, args[idx]);
                }
                return this;
            }
        }
    }
