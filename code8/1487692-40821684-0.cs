    class ExplicitSelector : Selector
    {
        public ExplicitSelector(
            IConstructorScorer constructorScorer, 
            IEnumerable<IInjectionHeuristic> injectionHeuristics) 
            : base(constructorScorer, injectionHeuristics)
        {
        }
        public override IEnumerable<MethodInfo> SelectMethodsForInjection(Type type)
        {
            // Gets all implemented interface and grabs an InterfaceMapping. 
            var implementedInterfaces = type.GetInterfaces();
            foreach (var map in implementedInterfaces.Select(type.GetInterfaceMap))
            {
                for (var i = 0; i < map.InterfaceMethods.Length; i++)
                {
                    // Check each interface method for the Inject attribute, and if present
                    if (map.InterfaceMethods[i].CustomAttributes.Any(x => x.AttributeType == typeof (InjectAttribute)))
                    {
                        // return the target method implementing the interface method. 
                        yield return map.TargetMethods[i];
                    }
                }
            }
            // Defer to NInject's implementation for other bindings. 
            foreach (var mi in base.SelectMethodsForInjection(type))
            {
                yield return mi;
            }
        }
    }
