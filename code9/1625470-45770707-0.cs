    private void Serializer_UnknownElement(object sender, XmlElementEventArgs e)
    {
        var group = (DeactivationsGroup)e.ObjectBeingDeserialized;
        group.GroupNames.Add(e.Element.Name, new GroupName { Name = e.Element.InnerText });
    }
