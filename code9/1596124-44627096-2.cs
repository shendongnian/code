              static void InspectDelegate(object obj)
                    {
                        if (!(obj is Delegate del))
                        {
                            return;
                        }
                        var returnType = del.Method.ReturnType.Name;
                        var parameters = del.Method.GetParameters();
                        Dictionary<string, string> argNames = 
                                  parameters.ToDictionary(a => a.Name, b => b.ParameterType.Name);
                var delType = d.GetType().Name;
                var delInfo = delType.Split('`');
                var delName = delInfo[0];
                var parametersCount = delInfo[1];
                switch (delName)
                {
                    case "Action":
                        //..
                        break;
                    case "Func":
                        //..
                        break;
    
                    default:
                        break;
                }
                    }
                    static void Main(string[] args)
                    {
                        Action<string, int> act = (x, y) => { Console.WriteLine(x.Take(y)); };
                        InspectDelegate(act);
                    }
