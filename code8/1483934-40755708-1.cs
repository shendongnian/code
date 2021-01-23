    public void FlattenNodeRecursive(XElement item) {
    
                var children_elements = item.Elements();
    
                if ( IsSVGElem(item, "g") &&
                    HasAttr(item,"transform") &&
                    !item.IsEmpty &&
                    item.Elements().Any((XElement inner) => { return IsSVGElem(inner, "path") || IsSVGElem(inner, "text") || IsSVGElem(inner, "g"); }) &&
                    item.Elements().Any((XElement inner) => { return !IsSVGElem(inner, "tspan"); })
                   ) {
                    
                    XAttribute parent_attribute = item.Attribute("transform");
                    foreach (var inner in children_elements) {
                        if (HasAttr(inner, "transform")) {
                                inner.Attribute("transform").SetValue(ConcatenateTransforms((parent_attribute.Value.Trim() + " " + inner.Attribute("transform").Value.Trim())).Trim());
                            } else {
                                XAttribute attribute = new XAttribute("transform", parent_attribute.Value.Trim());
                                inner.Add(attribute);
                            }
                        }
    
                    parent_attribute.Remove();
    
                }
    
                foreach(XElement xelem in children_elements){
                    if(xelem.Elements() != null) {
                        FlattenNodeRecursive(xelem);
                    }
    
                }
            }
