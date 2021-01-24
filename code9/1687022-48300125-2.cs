    var currentAssembly = Assembly.GetExecutingAssembly();
            var callerAssemblies = new StackTrace().GetFrames()
                .Where(x => x.GetMethod() != null && x.GetMethod().ReflectedType != null )
                        .Select(x => x.GetMethod().ReflectedType.Assembly).Distinct()
                        .Where(x => x.GetReferencedAssemblies().Any(y => y.FullName == currentAssembly.FullName));
            var initialAssembly1 = callerAssemblies.Last();
