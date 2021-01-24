    public static void IterateParams(Parameter[] parameters, int depth = 0)
    {
        // If we had iterated each parameter
        if (depth == parameters.Length)
        {
            // Then do something with values, for example print it
            int[] values = parameters.Select(p => p.Value).ToArray();
            Console.WriteLine(string.Join(", ", values));
        }
        else // Else iterate through the values of the next parameter
        {
            var parameter = parameters[depth];
            for (int i = parameter.Min; i < parameter.Max; i++)
            {
                parameter.Value = i;
                IterateParams(parameters, depth + 1);
            }
        }
    }
    public static void Main()
    {
        var Params = new List<Parameter>();
        Params.Add(new Parameter { Min = 7, Max = 12, Value = 9 });
        Params.Add(new Parameter { Min = 18, Max = 24, Value = 21 });
        Params.Add(new Parameter { Min = 49, Max = 60, Value = 54 });
        IterateParams(Params.ToArray());
    }
