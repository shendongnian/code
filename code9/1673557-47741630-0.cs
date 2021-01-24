    var testImpl = new TestImpl();
            var interfaceTargeMethods = testImpl.GetType().GetInterfaceMap(typeof(ITest)).TargetMethods;
            foreach (var methodInfo in testImpl.GetType().GetMethods())
            {
                if (interfaceTargeMethods.Contains(methodInfo))
                {
                    // do something...
                }    
            }
