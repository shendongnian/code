    public static class MyConsole
    {
        public static void Test()
        {
            Console.Out
                .Columns(10, 40, 60)
                .WriteLine("foo", "bar", "baz")
                .WriteLine("LOL", "WUT", "BBQ")
                .WriteLine("HA", "ha", "ha");
            var cols = Console.Error.Columns(10, 40, 30);
            cols.WriteLine("Mary", "Had", "a");
            cols.WriteLine("Little", "lamb", "it's");
        }
        public static ColumnWriter Columns(params int[] widths) => new ColumnWriter(Console.Out, widths);
        public static ColumnWriter Columns(this TextWriter writer, params int[] widths) => new ColumnWriter(writer, widths);
        public class ColumnWriter
        {
            public ColumnWriter(TextWriter writer, int[] widths)
            {
                Debug.Assert(writer != null);
                Debug.Assert(widths != null);
                _writer = writer;
                _widths = widths;
            }
            private TextWriter _writer;
            private int[] _widths;
            public ColumnWriter Line()
            {
                _writer.WriteLine();
                return this;
            }
            public ColumnWriter Write(params object[] args)
            {
                Debug.Assert(args.Length == _widths.Length);
                var count = Math.Min(_widths.Length, args.Length);
                for (int idx = 0; idx < count; ++idx)
                {
                    var fmt = "{0," + _widths[idx] + "}";
                    _writer.Write(fmt, args[idx]);
                }
                return this;
            }
            public ColumnWriter WriteLine(params object[] args)
            {
                return Write(args).Line();
            }
        }
    }
