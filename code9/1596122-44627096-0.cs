                static void InspectDelegate(object del)
                {
                     if (!(del is Delegate))
                      {
                         return;
                      }
                    var d = (Delegate)del;
                    if(d == null) return;
                    var returnType = d.Method.ReturnType.Name;
                    var parameters = d.Method.GetParameters();
                    Dictionary<string, string> argNames = 
                              parameters.ToDictionary(a => a.Name,b => b.ParameterType.Name);
                    Console.WriteLine();
                }
                static void Main(string[] args)
                {
                    Action<string, int> act = (x, y) => { Console.WriteLine(x.Take(y)); };
                    InspectDelegate(act);
                }
