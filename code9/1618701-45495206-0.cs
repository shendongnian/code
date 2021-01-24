        public static void RegisterAllImplementations(this UnityContainer container, Type openInterfaceType)
        {
            int registerCount = 0;
            // Iterate all types from current assembly
            foreach (var typeItem in Assembly.GetExecutingAssembly().GetTypes())
            {
                foreach (var interaceItem in typeItem.GetInterfaces())
                {
                    if (interaceItem.IsGenericType && interaceItem.GetGenericTypeDefinition() == openInterfaceType)
                    {
                        container.RegisterType(interaceItem, typeItem, $"{registerCount++}");
                    }
                }
            }
        }
