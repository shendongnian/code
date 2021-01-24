    @model object
    
    @if (Model is MyNamespace.Class1)
    {
        Html.RenderPartial("MyNamespaceClass1", Model);
    }
    
    @if (Model is MyOtherNamespace.Class1)
    {
        Html.RenderPartial("MyOtherNamespaceClass1", Model);
    }
