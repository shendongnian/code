    public static class MyConsole
    {
        public static void Test()
        {
            //  Not a great idea.
            MyConsole.WriteLines(10, 10)("foo", "bar")("baz", "planxty");
            //  Truly awful idea.
            MyConsole.Columns(10, 10)["foo", "bar"]["baz", "planxty"].End();
        }
        public static ColumnWriter Columns(params int[] widths) => new ColumnWriter(widths);
        #region Not a great idea
        //  Evk showed me how to make this work. 
        public delegate Params Params(params object[] values);
        public static Params WriteLines(params int[] widths)
        {
            var writer = new ColumnWriter(widths);
            return new Params(writer.WriteLineParams);
        }
        #endregion Not a great idea
        public class ColumnWriter
        {
            public ColumnWriter(int[] widths)
            {
                _widths = widths;
            }
            private int[] _widths;
            #region Truly awful idea.
            public ColumnWriter this[object o] => WriteLine(o);
            public ColumnWriter this[object o1, object o2] => WriteLine(o1, o2);
            public ColumnWriter this[object o1, object o2, object o3] => WriteLine(o1, o2, o3);
            //  ...moar overloards...
            //  In C# x[0]; is an expression, not a statement. 
            //  x[0].End(); is a statement. Horrible, most horrible. 
            //  Maybe I should name it FireMe() instead of End()
            public void End() { }
            #endregion Truly awful idea.
            public ColumnWriter Line()
            {
                Console.WriteLine();
                return this;
            }
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
            public ColumnWriter WriteLine(params object[] args) 
                => Write(args).Line();
            #region Not a great idea
            public Params WriteLineParams(params object[] args)
            {
                WriteLine(args);
                return WriteLineParams;
            }
            #endregion Not a great idea
        }
    }
