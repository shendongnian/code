            var an = new AssemblyName("Foo");
            for (int i = 0; i < 10000; i++)
            {
                var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
                ab.DefineDynamicModule("Bar");
            }
