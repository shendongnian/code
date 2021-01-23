    EA.Attribute headerName = eleName.Attributes.AddNew("Header", "char");
    headerName.Update();
    
    EA.AttributeTag decAtt = headerName.TaggedValues.AddNew("Description","");
    decAtt.Value = "<memo>";
    decAtt.Notes = "Description needs to be entered";
    decAtt.Update();
