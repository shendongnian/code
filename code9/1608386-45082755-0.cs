    var Member = ViewData.ModelMetadata.ContainerType.GetMember(ViewData.ModelMetadata.PropertyName);
    var Attribute = Member[0].GetCustomAttribute<MyCustomAttribute>();
    if(Attribute != null)
    {
        <p>@Attribute.MyProperty</p>
    } 
