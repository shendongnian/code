    public string GetMethodBodyByName(string methodName)
        {
            ModuleDefMD md = ModuleDefMD.Load(filename);
            foreach (TypeDef type in md.Types)
            {
                foreach (MethodDef method in type.Methods)
                {
                    for (int i = 0; i < type.Methods.Count; i++)
                    {
                        if (method.HasBody)
                        {
                            if (method.Name == methodName)
                            {
                                var instr = method.Body.Instructions;
                                return String.Join("\r\n", instr);
                            }
                        }
                    }
                }
            }
            return "";
        }
