     static HashSet<string> BuildDependency(AssemblyDefinition ass, MethodReference method)
            {
                var types = ass.Modules.SelectMany(m => m.GetTypes()).ToArray();
                var r = new HashSet<string>();
                
                DrillDownDependency(types, method,0,r);
        
                return r;
            }
    
        static void DrillDownDependency(TypeDefinition[] allTypes, MethodReference method, int depth, HashSet<string> result)
        {
            foreach (var type in allTypes)
            {
                foreach (var m in type.Methods)
                {
                    if (m.HasBody &&
                        m.Body.Instructions.Any(il =>
                        {
                            if (il.OpCode == Mono.Cecil.Cil.OpCodes.Call)
                            {
                                var mRef = il.Operand as MethodReference;
                                if (mRef != null && string.Equals(mRef.FullName,method.FullName,StringComparison.InvariantCultureIgnoreCase))
                                {
                                    return true;
                                }
                            }
                            return false;
                        }))
                    {
                        result.Add(new string('\t', depth) + m.FullName);
                        DrillDownDependency(allTypes,m,++depth, result);
                    }
                }
            }
        }
