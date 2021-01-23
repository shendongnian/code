    public static class B_Extensions
    {
       public static void SetString(this A a, string s)
       {
          a.Astring = s;
       }
    }
    public class A
    {
       public string Astring { get; set; }
    }
    // In any other class
    private void DoSomething()
    {
        var a = new A();
        a.SetString("Something");
    }
