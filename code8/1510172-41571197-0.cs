    using System.Linq;
    using a=System.Console;
    using b=System.Collections.Generic.List<int>;
    using c=System.Int32;
    using d=System.String;
    namespace e
    {
        class f
        {
            static d x=>a.ReadLine();
            static c _(d f)=>c.Parse(f);
            static d[] g(d f)=>f.Split();
            static void Main()
            {
                var n=_(x);var p=new b();var r=p.ToList();var i=1^1;
                while(n-->0)g(x).ToList().ForEach(v=>((i++%2==0)?p:r).Add(_(v)));
            }
        }
    }
