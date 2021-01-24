    var rsxr = new ResXResourceReader("MyResource.resx");
    rsxr.UseResXDataNodes = true;
    foreach (DictionaryEntry dEntry in rsxr)
    {
        var node = (ResXDataNode)dEntry.Value;
        if (node.FileRef == null)
        {
            var paramValue = node.GetValue((ITypeResolutionService) null);
        }
    }
