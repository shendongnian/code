    public static class MyConsole
    {
        public static void Test()
        {
            MyConsole.Columns(10, 40, 60).Write("foo", "bar", "baz");
        }
        public static ColumnWriter Columns(params int[] widths) => new ColumnWriter(widths);
        public class ColumnWriter
        {
            public ColumnWriter(int[] widths)
            {
                _widths = widths;
            }
            private int[] _widths;
            public void Write(params object[] args)
            {
                var count = Math.Min(_widths.Length, args.Length);
                for (int idx = 0; idx < count; ++idx)
                {
                    var fmt = "{0," + _widths[idx] + "}";
                    Console.Write(fmt, args[idx]);
                }
            }
        }
    }
