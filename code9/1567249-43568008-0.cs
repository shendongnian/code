    var attributeOverrides = new XmlAttributeOverrides();
    var attributes = new XmlAttributes();
    if (SomeCondition())
    {
        attributes.XmlIgnore = true;
    }
    else
    {
        attributes.XmlElements.Add(new XmlElementAttribute("DealId"));
    }
    attributeOverrides.Add(typeof(MyModel), "ID", attributes);
    // when instantiating the XmlSerializer we specify the attribute overrides
    var serializer = new XmlSerializer(typeof(MyModel), attributeOverrides);
    var model = new MyModel
    {
        ID = 5,
    };
    serializer.Serialize(Console.Out, model);
