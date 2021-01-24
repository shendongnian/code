    var commonProps = typeof(CommonProperty).GetProperties(BindingFlags.Static | BindingFlags.Public);
    var itemProps = list.GetType().GenericTypeArguments[0].GetProperties().ToDictionary(k => k.Name, v => v);
    var result = list.Select(l => commonProps.ToDictionary(
        k => k.GetValue(null),
        v => itemProps[v.Name].GetValue(l)
    ));
