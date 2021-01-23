    var sr3 = new StringReader(xml);
    var xr3 = XmlReader.Create(sr3, new XmlReaderSettings { CheckCharacters = false });
    // xr3.Normalization is not accessible
    xr3.GetType()
        .GetProperty("Normalization", BindingFlags.Instance | BindingFlags.NonPublic)
        .SetValue(xr3, true);
    var obj3 = (MyObject)ser.Deserialize(xr3);
