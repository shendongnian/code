    var instance = specField.GetValue(null);
    var instanceType = instance.GetType();
    var methodInfo = instanceType.GetMethod("IsSatisfiedBy");
    var result2 = methodInfo.Invoke(instance, new object[] { entity }); // <<-- instance added.
            
