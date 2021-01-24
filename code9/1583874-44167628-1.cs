    abstract class AbsC
    {
       public double DoSomething() { return 3.14; }
    }
    class M
    {
       readonly AbsC _p;
       public M(AbsC p)
       {
          _p = p;
       }
       Compute()
       {
          var x = p.DoSomething();
       }
    }
