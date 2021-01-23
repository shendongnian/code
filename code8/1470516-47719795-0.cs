    var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
    if (classAttr != null)
    {
        output.Attributes.Remove(classAttr);
    }
    output.Attributes.Add("class", $"active {classAttr?.Value}");
