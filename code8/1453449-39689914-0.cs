                var type = typeof(IntStaticClass);
                var types = type.GetNestedTypes(BindingFlags.NonPublic);
                MethodInfo methodInfo = types[0].GetMethod("Create");
                object classInstance = System.Activator.CreateInstance(types[0], null);
                object[] parametersArray = new object[2] { new Obj1(), new Obj2() };
                var result = methodInfo.Invoke(classInstance, parametersArray);
