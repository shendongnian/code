    using Microsoft.FSharp.Core;
    ...
    public static Program.R x {
        get { return \u0024Program.x\u00406; }
    }
    [EntryPoint]
    public static int main(string[] argv)
    {
        \u0024Program.init\u0040 = 0;
        int init = \u0024Program.init\u0040;
        ExtraTopLevelOperators
          .PrintFormatLine<FSharpFunc<Program.R, Unit>>(
              (PrintfFormat<FSharpFunc<Program.R, Unit>, TextWriter, Unit, Unit>)
              new PrintfFormat<FSharpFunc<Program.R, Unit>, TextWriter, Unit, Unit, Program.R>("%A")).Invoke(Program.x);
        return 0;
    }
    public sealed class R : IEquatable<Program.R>, IStructuralEquatable, IComparable<Program.R>, IComparable, IStructuralComparable
    {
        internal Program.R r\u0040;
        public Program.R r { get { return this.r\u0040; } }
        public R(Program.R r) { this.r\u0040 = r; }
    }
