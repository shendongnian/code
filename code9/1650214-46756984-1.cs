    if (property.GetType().IsGenericType
        && property.GetType().GetGenericTypeDefinition() == typeof(EnumProperty<>)) {
      var helperType = typeof(EnumPropertyHelper<>).MakeGenericType(property.GetType().GetGenericTypeArguments());
      var helper = (EnumPropertyHelper)Activator.CreateInstance(helper);
      helper.DoSomething(property);
    }
