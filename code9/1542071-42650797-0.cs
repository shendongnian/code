    public class Derived : Base
    {
         private Derived() {}
    
         public static Derived Create() => new Derived();
    
         public Func<bool> Licensed { get; private set; }
         public Func<bool> Enabled { get; private set; }
    
         public void LicensedIf(Func<Derived, bool> licensingCondition)
                => Licensed = () => licensingCondition(this);
        
         public void EnabledIf(Func<Derived, bool> enablingCondition)
                => Enabled = () => enablingCondition(this);
    }
    
    // Fluent configuration of your *licensable object* gets self-documented
    // by the usage!
    // Oh, and see how EnableIf() takes advantage of C#6's null conditional
    // operator to invoke the "Licensed" delegate if its really set. This is
    // so safe!
    var derived = Derived.Create().LicenseIf(d => true)
                                  .EnableIf(d => d.Licensed?.Invoke() && true);
