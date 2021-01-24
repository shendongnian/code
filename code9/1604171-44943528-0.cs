           foreach (XmlSchema schema in xss.Schemas())
                {
                    foreach (System.Collections.DictionaryEntry ag in schema.AttributeGroups)
                    {
                        if (ag.Value is XmlSchemaAttributeGroup)
                        {
                            var attributeGroup = (XmlSchemaAttributeGroup)ag.Value;
    
    
                            foreach (var attributeOrGroup in attributeGroup.Attributes)
                            {
                                if (attributeOrGroup is XmlSchemaAttribute)
                                {
                                    var attribute = (XmlSchemaAttribute)attributeOrGroup;
                                    if (attribute.DefaultValue != null)
                                    {
                                        attribute.DefaultValue = null;
                                    }
                                    if (attribute.FixedValue != null)
                                    {
                                        attribute.FixedValue = null;
                                    }
                                }
                            }
                        }
                    }
                    foreach (System.Collections.DictionaryEntry st in schema.SchemaTypes)
                    {
                        if (st.Value is XmlSchemaComplexType)
                        {
                            var c = (XmlSchemaComplexType)st.Value;
    
                            foreach (var g in c.Attributes)
                            {
                                if (g is XmlSchemaAttribute)
                                {
                                    var attr = (XmlSchemaAttribute)g;
                                    if (attr.DefaultValue != null)
                                    {
                                        attr.DefaultValue = null;
    
                                    }
                                    if (attr.FixedValue != null)
                                    {
                                        attr.FixedValue = null;
                                    }
    
                                }
                            }
                        }
                    }
                }
