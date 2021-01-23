    internal class Program
        {
            public enum WhatToDo
            {
                Something,
                SomethingElse
            }
    
            public static void MyMethod(WhatToDo what)
            {
                switch (what)
                {
                    case WhatToDo.Something:
                        Struct1 param1 = new Struct1();
                        MygenericMethod(param1);
                        break;
                    case WhatToDo.SomethingElse:
                        Struct2 param2 = new Struct2();
                        MygenericMethod(param2);
                        break;
                }
            }
    
            public static void MygenericMethod<T>(T someParam) where T : struct
            {
            }
    
            public struct Struct1
            {
            }
    
            public struct Struct2
            {
            }
        }
