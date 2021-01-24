    interface class AbsC
    {
       double DoSomething();
    }
    class C : AbsC
    {
       public double DoSomething() { return 3.14; }
    }
    class M
    {
       public AbsC _p;
       public M(AbsC p)
       {
          _p = p;
       }
       public void Compute()
       {
          var x = p.DoSomething();
       }
    }
