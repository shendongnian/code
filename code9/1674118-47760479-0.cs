    class MapOpenGenericTypesToInterfacesConvention : IRegistrationConvention {
        public void ScanTypes(TypeSet types, Registry registry) {
            var openInterfaces = types.FindTypes(TypeClassification.Open | TypeClassification.Interfaces).ToArray();
            var openConcrete = types.FindTypes(TypeClassification.Open | TypeClassification.Concretes);
            foreach (var type in openConcrete) {
                foreach (var iface in openInterfaces) {
                    if (type.GetInterfaces().Where(c => c.IsGenericType).Any(ti => ti.GetGenericTypeDefinition() == iface)) { 
                        registry.For(iface).Use(type);
                    }
                }
            }
        }
    }
