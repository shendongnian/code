    new Dictionary<string, Tuple<OpCode, Action<string>>>
    {
        {
            "call",
            Tuple.Create<OpCode, Action<string>>
              (OpCodes.Call,ParseStaticCall)
        }
    };
    static void ParseStaticCall(Opcpde opcode,
                                string call,
                                ILProcessor processor)
    {
        string assembly, namespaceName, type, method;
        int numOfParameters;
        var moduleDefenition = AssemblyResolver.Resolve(assembly).MainModule;
        var methodReference = 
            new ReferenceFinder(moduleDefenition).
                GetMethodReference(typeof (Console),
                    md => md.Name == methodName &&
                    md.Parameters.Count == numOfParameters);
            processor.Emit(opcode, methodReference);
    }
