    void DoThiks(string CalledClass) // where CalledClass = "Exemplo"
        {
            Type ExemploType = Type.GetType("TestesWindowsForms.TesteReflexao.Exemplo");
            ConstructorInfo ExemploConstructor = ExemploType.GetConstructor(Type.EmptyTypes);
            object ExemploClassObject = ExemploConstructor.Invoke(new object[] { });
            //Solution here:
            //Creating the object to be assigned to the property of ExampleClassObject
            Type HappyType = Type.GetType("TestesWindowsForms.TesteReflexao.Happy");
            object HappyClassObject = Activator.CreateInstance(HappyType);
            PropertyInfo HappyPropery = ExemploType.GetProperty("Happy");
            HappyPropery.SetValue(ExemploClassObject, HappyClassObject);
            //That was the assignment. Now I have the Happy property of the type object pointing to an object of type Happy.
            MethodInfo EstaHappy = HappyType.GetMethod("IsHappy");
            bool Resultado = (bool)EstaHappy.Invoke(HappyClassObject, null);
            MessageBox.Show(Resultado.ToString());
        }
