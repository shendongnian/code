            var an = new AssemblyName("Foo");
            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
            for (int i = 0; i < 10000; i++)
            {
                ab.DefineDynamicModule("Bar" + i.ToString("000"));
            }
