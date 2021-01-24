    namespace BarAssembly
    {
       public ref struct Bar abstract sealed // "abstract sealed" == C#'s "static"
       {
          static double Add(double a, double b) {
             return foo::Add(a, b);
          }
       }
    }
