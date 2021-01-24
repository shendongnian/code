    var boxedInt = (object)1;
    var boxedFloat = (object)1f;
    dynamic dynamicInt = boxedInt;
    dynamic dynamicFloat = boxedFloat;
    var intResult = new Transformations().TransformFrom(dynamicInt); // works
    var floatResult = new Transformations().TransformFrom(dynamicFloat); // throws binder exception
