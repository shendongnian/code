    Dictionary<string, object> vars = new Dictionary<string, object>();
    List<MethodInfo> lines = new List<MethodInfo>();
    lines.Add(type.GetMethod("Line1"));
    lines.Add(type.GetMethod("Line2"));
    lines.Add(type.GetMethod("Line3"));
    vars["x"] = lines[0].Invoke(instance, new object[] { });
    vars["y"] = lines[1].Invoke(instance, new object[] { });
    vars["@return"] = lines[2].Invoke(instance, new object[] { vars["x"], vars["y"] });
