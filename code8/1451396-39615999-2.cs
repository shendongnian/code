    MethodInfo genericMethod = this.GetType().GetMethod("SomeMethode", BindingFlags.NonPublic);
    foreach (var a in typesWithMyAttribute)
    {
        MethodInfo constructedMethod = genericMethod.MakeGenericMethod(a.Type);
        var propList = this.GetType().GetProperty(a.Type.Name + "List").GetValue(this);
        constructedMethod.Invoke(this, new[]{propList});
    }
