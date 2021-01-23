    public void UpdateHierarchical(Base someObject)
    {
        UpdateHierarchical(someObject.GetType(), someObject);
    }
    
    private void UpdateHierarchical(Type type, object obj)
        // if the object has a base class
        // call this function recursively with type = base type
        // if this type has has an Update, call it,
        Type type = obj.GetType();        // the type of obj
        Type baseType = type.BaseType();  // the base type of obj
        if (baseType != null)             // there is a base type
            UpdateHierarchical(baseType, obj);
        // now that all base Update() are called,
        // check if this type has an Update
        MethodInfo updateInfo = type.GetMethod("Update")
        if (updateInfo != null)
        {   // this type has an Update()
            updateInfo.Invoice(obj, null);
        }
    }
