    public class Sample
    {
        private readonly string _targetFileName;
        private readonly ModuleDefinition _module;
        public ModuleDefinition TargetModule { get { return _module; } }
        public Sample(string targetFileName)
        {
            _targetFileName = targetFileName;
            // Read the module with default parameters
            _module = ModuleDefinition.ReadModule(_targetFileName);
        }
        public void Run(string type, string method)
        {
            // Retrive the target class. 
            var targetType = _module.Types.Single(t => t.Name == type);
            // Retrieve the target method.
            var runMethod = targetType.Methods.Single(m => m.Name == method);
            // Get a ILProcessor for the Run method
            
            // get log entry method ref to create instruction
            var logEntryMethodReference = _module.Types.Single(t => t.Name == "Trace").Methods.Single(m => m.Name == "LogEntry");
            List<Instruction> newInstructions = new List<Instruction>();
            var arrayDef = new VariableDefinition(new ArrayType(_module.TypeSystem.Object)); // create variable to hold the array to be passed to the LogEntry() method            
            runMethod.Body.Variables.Add(arrayDef);  // add variable to the method          
            var processor = runMethod.Body.GetILProcessor();
            newInstructions.Add(processor.Create(OpCodes.Ldc_I4, runMethod.Parameters.Count));  // load to the stack the number of parameters                      
            newInstructions.Add(processor.Create(OpCodes.Newarr, _module.TypeSystem.Object)); // create a new object[] with the number loaded to the stack           
            newInstructions.Add(processor.Create(OpCodes.Stloc, arrayDef)); // store the array in the local variable
            // loop through the parameters of the method to run
            for (int i = 0; i < runMethod.Parameters.Count; i++)
            {
                newInstructions.Add(processor.Create(OpCodes.Ldloc, arrayDef)); // load the array from the local variable
                newInstructions.Add(processor.Create(OpCodes.Ldc_I4, i)); // load the index
                newInstructions.Add(processor.Create(OpCodes.Ldarg, i+1)); // load the argument of the original method (note that parameter 0 is 'this', that's omitted)
                if (runMethod.Parameters[i].ParameterType.IsValueType)
                {
                    newInstructions.Add(processor.Create(OpCodes.Box, _module.TypeSystem.Object)); // boxing is needed for value types
                }
                else
                { 
                    newInstructions.Add(processor.Create(OpCodes.Castclass, _module.TypeSystem.Object)); // casting for reference types
                }
                newInstructions.Add(processor.Create(OpCodes.Stelem_Ref)); // store in the array
            }
            newInstructions.Add(processor.Create(OpCodes.Ldstr, method)); // load the method name to the stack
            newInstructions.Add(processor.Create(OpCodes.Ldloc, arrayDef)); // load the array to the stack
            newInstructions.Add(processor.Create(OpCodes.Call, logEntryMethodReference)); // call the LogEntry() method
            
            foreach (var newInstruction in newInstructions.Reverse<Instruction>()) // add the new instructions in referse order
            {
                var firstInstruction = runMethod.Body.Instructions[0];
                processor.InsertBefore(firstInstruction, newInstruction);
            }
            // Write the module with default parameters
            _module.Write(_targetFileName);
        }
    }
