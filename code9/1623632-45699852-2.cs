    @model object
    @if (Model is MyNamespace.Class1)
    {
        var class1 = Model as MyNamespace.Class1;
        // view code for this type
    }
    @if (Model is MyOtherNamespace.Class1)
    {
        var class1 = Model as MyOtherNamespace.Class1;
        // view code for this type
    }
