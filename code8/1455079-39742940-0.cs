       // Get the constructor and create an instance of MagicClass
            Type magicType = Type.GetType("MagicClass");
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(new object[]{});
    
            // Get the ItsMagic method and invoke with a parameter value of 100
    
            MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
            object magicValue = magicMethod.Invoke(magicClassObject, new object[]{100});
