        static void PrintGraph(Function function, int spaces, bool useName = false)
        {
            string indent = new string('.', spaces);
            if (function.Inputs.Count() == 0)
            {
                Console.WriteLine(indent + "(" + (useName ? function.Name : function.Uid) + ")" +
                    "(" + function.OpName + ")" + function.AsString());
                return;
            }
            foreach (var input in function.Inputs)
            {
                Console.WriteLine(indent + "(" + (useName ? function.Name : function.Uid) + ")" +
                    "(" + function.OpName + ")" + "->" +
                    "(" + (useName ? input.Name : input.Uid) + ")" + input.AsString());
            }
            foreach (var input in function.Inputs)
            {
                if (input.Owner != null)
                {
                    Function f = input.Owner;
                    PrintGraph(f, spaces + 4, useName);
                }
            }
        }
