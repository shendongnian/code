    container.RegisterSingletonConditional<IBlobAccessClientSource>(
       src,
       c => c.Consumer.Target.Parameter.Name.Contains("src"));
    
    container.RegisterSingletonConditional<IBlobAccessClientDestination>(
       dest,
       c => c.Consumer.Target.Parameter.Name.Contains("dest"));
