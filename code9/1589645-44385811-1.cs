        var arrayOfBaseClass = 
            (
                from instance 
                in results 
                select instance.GetComponent(blueprint.Field.FieldType.GetElementType()))
            .ToArray();
        
        // NEWCODE --------------------------------------------------------
        MethodInfo bindArray= typeof(DataGlueController).GetMethod("BindToTypedArray");
        MethodInfo bindArrayTyped=bindArray.MakeGenericMethod(blueprint.Field.FieldType.GetElementType());
        bindArrayTyped.Invoke(this, new object[] { o, blueprint.Field, arrayOfBaseClass });
        // END NEWCODE ----------------------------------------------------
        
        // blueprint.Field.SetValue(o, arrayOfBaseClass); <- this is done in the BindToTypedArray function
