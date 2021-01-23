    static void AddToCollection(object collection, object item)
    {
        MethodInfo addMethod = collection.GetType().GetMethod("Add");
        if (addMethod == null || addMethod.GetParameters().Length != 1)
        {
            // handle your error
            return;
        }
        ParameterInfo parameter = addMethod.GetParameters().First();
        if (parameter.ParameterType.Equals(item.GetType()))
        {
            addMethod.Invoke(collection, new object[] { item });
        }
        else
        {
            // handle your error
        }
    }
