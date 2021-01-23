    var callingMethods = new StackTrace().GetFrames()
                             .Select(v => v.GetMethod())
                             .Where(m => !m.DeclaringType.Assembly.GlobalAssemblyCache
                                          && !m.DeclaringType.CustomAttributes.Any(ca => ca.AttributeType == typeof(CompilerGeneratedAttribute))
                                   )
                             .Select(m => m.Name);
