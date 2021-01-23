    Dim xdoc As New XDocument();
    xdoc = XDocument.Parse(myXML);
    // Adding new element
    xdoc.Element(<Your_Parent_Node_Name>).Add(new XElement("<New_Element_Name>", "<New_Element_Value>"));
    // Deleting existing element
     xdoc.Descendants().Where(s =>s.Value == "<Element_To_Be_Removed>").Remove(); 
