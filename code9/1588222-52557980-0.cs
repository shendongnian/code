            static void ValidateMessage(XDocument xDoc)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add("", @"Messages_Schema.xsd");
            schemas.Compile();
            var schemaElements = (XmlSchemaElement)schemas.GlobalElements.Values.OfType<XmlSchemaObject>()
                .FirstOrDefault(e => ((XmlSchemaElement)e).Name == xDoc.Root?.Name.LocalName);
            var xmlElement =
                (XmlSchemaSequence)((XmlSchemaComplexType)schemaElements?.ElementSchemaType)?.ContentTypeParticle;
            var elementNameList = new Dictionary<string, XmlSchemaObject>();
            AddElementsInDictionary(xmlElement?.Items.OfType<XmlSchemaObject>().ToList(), elementNameList, new List<string>());
            var errorList = new List<string>();
            bool elementFixed;
            do
            {
                errorList.Clear();
                ValidateElements(xDoc.Root?.Elements().ToList(), elementNameList, schemas, new List<string>(), errorList);
                errorList.ForEach(e =>
                {
                    if (!ErrorLogs.Contains(e))
                        ErrorLogs.Add(e);
                });
                elementFixed = false;
                if (XElementsToDelete.Any() || XElementsToCut.Any() || XElementsInvalid.Any())
                {
                    XElementsInvalid.ForEach(xElement =>
                    {
                        var xParent = xElement.Parent;
                        var xParentSchema =
                            (xParent?.GetSchemaInfo()?.SchemaType as XmlSchemaComplexType)?.ContentTypeParticle as
                            XmlSchemaSequence;
                        var elementNameLists = new List<string>();
                        AddElementsInList(xParentSchema?.Items.OfType<XmlSchemaObject>().ToList(), elementNameLists);
                        var index = elementNameLists.IndexOf(xElement.Name.LocalName);
                        if (index == 0)
                        {
                            xElement.Remove();
                            var log = $"    Move: {xElement.Name} element to the top of the sequence";
                            if (!FixLogs.Contains(log))
                                FixLogs.Add(log);
                            elementFixed = true;
                            xParent?.AddFirst(xElement);
                        }
                        else
                        {
                            var xNextElement = xElement.NextNode as XElement;
                            var indexNext = elementNameLists.IndexOf(xNextElement?.Name.LocalName);
                            if (indexNext - index > 1)
                            {
                                var xPreviousElement = xElement.PreviousNode as XElement;
                                var indexPrevious = elementNameLists.IndexOf(xPreviousElement?.Name.LocalName);
                                do
                                {
                                    indexPrevious -= 1;
                                    var xLastValidElement = xParent?.Element(elementNameLists[indexPrevious]);
                                    if (xLastValidElement == null) continue;
                                    xPreviousElement?.Remove();
                                    var log = $"    Move: {xPreviousElement?.Name} element after {xLastValidElement.Name}";
                                    if (!FixLogs.Contains(log))
                                        FixLogs.Add(log);
                                    elementFixed = true;
                                    xLastValidElement.AddAfterSelf(xPreviousElement);
                                    break;
                                } while (indexPrevious > 0);
                            }
                            else
                            {
                                do
                                {
                                    index -= 1;
                                    var xLastValidElement = xParent?.Element(elementNameLists[index]);
                                    if (xLastValidElement == null) continue;
                                    xElement.Remove();
                                    var log = $"    Move: {xElement.Name} element after {xLastValidElement.Name}";
                                    if (!FixLogs.Contains(log))
                                        FixLogs.Add(log);
                                    elementFixed = true;
                                    xLastValidElement.AddAfterSelf(xElement);
                                    break;
                                } while (index > 0);
                            }
                        }
                    });
                    XElementsToDelete.ForEach(e =>
                    {
                        e.Remove();
                        var log = $"    Delete: {e.Name} element";
                        if (!FixLogs.Contains(log))
                            FixLogs.Add(log);
                        elementFixed = true;
                    });
                    XElementsToCut.ForEach(e =>
                    {
                        var schemaType = (XmlSchemaSimpleType)e.GetSchemaInfo()?.SchemaType;
                        var restriction = (XmlSchemaSimpleTypeRestriction)schemaType?.Content;
                        var enumFacets = restriction?.Facets.OfType<XmlSchemaMaxLengthFacet>();
                        var maxLengthFacet = enumFacets?.ToList().FirstOrDefault();
                        if (maxLengthFacet != null)
                        {
                            var maxLength = int.Parse(maxLengthFacet.Value);
                            var log = $"    Cut: {e.Name} value to maxLength: {maxLength}";
                            if (!FixLogs.Contains(log))
                                FixLogs.Add(log);
                            elementFixed = true;
                            e.Value = e.Value.Substring(0, maxLength);
                        }
                    });
                    if (!elementFixed)
                    {
                        var log = "    Cannot fix:";
                        if (!FixLogs.Contains(log))
                            FixLogs.Add(log);
                        errorList.ForEach(e =>
                        {
                            if (!FixLogs.Contains($"        {e}"))
                                FixLogs.Add($"        {e}");
                        });
                    }
                }
                XElementsToDelete.Clear();
                XElementsInvalid.Clear();
                XElementsToCut.Clear();
            } while (errorList.Count > 0 && elementFixed);
            Console.WriteLine($"Validating a {xDoc.Root?.Name.LocalName}");
            Console.WriteLine("");
            ErrorLogs.ForEach(e =>
            {
                Console.WriteLine("    {0}", e);
            });
            Console.WriteLine("");
            Console.WriteLine("Fixing");
            Console.WriteLine("");
            FixLogs.ForEach(e =>
            {
                Console.WriteLine("{0}", e);
            });
            Console.WriteLine("");
            Console.WriteLine("Message {0}",
                errorList.Count > 0 ? "did not validate" : "validated");
            Console.ReadKey();
        }
        private static void AddElementsInList(IEnumerable<XmlSchemaObject> schemaObjectList,
            ICollection<string> schemaObjectKeys)
        {
            schemaObjectList.ToList().ForEach(se =>
            {
                switch (se.GetType().ToString())
                {
                    case "System.Xml.Schema.XmlSchemaElement":
                        var element = se as XmlSchemaElement;
                        var name = (se as XmlSchemaElement)?.QualifiedName.Name;
                        if (!schemaObjectKeys.Contains(name))
                            schemaObjectKeys.Add(name);
                        var elementSchemaType = element?.ElementSchemaType;
                        if (elementSchemaType != null)
                            AddElementsInList(new List<XmlSchemaObject> { elementSchemaType }, schemaObjectKeys);
                        break;
                    case "System.Xml.Schema.XmlSchemaComplexType":
                        break;
                    case "System.Xml.Schema.XmlSchemaSequence":
                        var sequence = se as XmlSchemaSequence;
                        var sequenceItems = sequence?.Items.OfType<XmlSchemaObject>().ToList();
                        if (sequenceItems != null)
                            AddElementsInList(sequenceItems, schemaObjectKeys);
                        break;
                    case "System.Xml.Schema.XmlSchemaChoice":
                        var choice = se as XmlSchemaChoice;
                        var choiceItems = choice?.Items.OfType<XmlSchemaObject>().ToList();
                        if (choiceItems != null)
                            AddElementsInList(choiceItems, schemaObjectKeys);
                        break;
                    case "System.Xml.Schema.XmlSchemaGroupRef":
                        var group = se as XmlSchemaGroupRef;
                        var groupParticle = group?.Particle;
                        if (groupParticle != null)
                            AddElementsInList(new List<XmlSchemaObject> { groupParticle }, schemaObjectKeys);
                        break;
                }
            });
        }
        private static void AddElementsInDictionary(IEnumerable<XmlSchemaObject> schemaObjectList,
            IDictionary<string, XmlSchemaObject> schemaObjectDictionary, IList<string> schemaObjectDictionaryKeys)
        {
            schemaObjectList.ToList().ForEach(se =>
            {
                switch (se.GetType().ToString())
                {
                    case "System.Xml.Schema.XmlSchemaElement":
                        var element = se as XmlSchemaElement;
                        schemaObjectDictionaryKeys.Add((se as XmlSchemaElement)?.QualifiedName.Name);
                        var path = string.Join("/", schemaObjectDictionaryKeys);
                        if (!schemaObjectDictionary.ContainsKey(path))
                            schemaObjectDictionary.Add(path, se);
                        var elementSchemaType = element?.ElementSchemaType;
                        if (elementSchemaType != null)
                            AddElementsInDictionary(new List<XmlSchemaObject> { elementSchemaType },
                                schemaObjectDictionary, schemaObjectDictionaryKeys);
                        if (schemaObjectDictionaryKeys.Count > 0)
                            schemaObjectDictionaryKeys.RemoveAt(schemaObjectDictionaryKeys.Count - 1);
                        break;
                    case "System.Xml.Schema.XmlSchemaComplexType":
                        var complexType = se as XmlSchemaComplexType;
                        var complexTypeParticle = complexType?.ContentTypeParticle;
                        if (complexTypeParticle != null)
                            AddElementsInDictionary(new List<XmlSchemaObject> { complexTypeParticle },
                                schemaObjectDictionary, schemaObjectDictionaryKeys);
                        break;
                    case "System.Xml.Schema.XmlSchemaSequence":
                        var sequence = se as XmlSchemaSequence;
                        var sequenceItems = sequence?.Items.OfType<XmlSchemaObject>().ToList();
                        if (sequenceItems != null)
                            AddElementsInDictionary(sequenceItems, schemaObjectDictionary, schemaObjectDictionaryKeys);
                        break;
                    case "System.Xml.Schema.XmlSchemaChoice":
                        var choice = se as XmlSchemaChoice;
                        var choiceItems = choice?.Items.OfType<XmlSchemaObject>().ToList();
                        if (choiceItems != null)
                            AddElementsInDictionary(choiceItems, schemaObjectDictionary, schemaObjectDictionaryKeys);
                        break;
                    case "System.Xml.Schema.XmlSchemaGroupRef":
                        var group = se as XmlSchemaGroupRef;
                        var groupParticle = group?.Particle;
                        if (groupParticle != null)
                            AddElementsInDictionary(new List<XmlSchemaObject> { groupParticle }, schemaObjectDictionary,
                                schemaObjectDictionaryKeys);
                        break;
                }
            });
        }
        private static void ValidateElements(List<XElement> xElementList,
            IReadOnlyDictionary<string, XmlSchemaObject> schemaObjectDictionary, XmlSchemaSet schemas,
            IList<string> schemaObjectDictionaryKeys, ICollection<string> errorList)
        {
            xElementList.ForEach(xElement =>
            {
                schemaObjectDictionaryKeys.Add(xElement.Name.LocalName);
                var path = string.Join("/", schemaObjectDictionaryKeys);
                if (schemaObjectDictionary.ContainsKey(path))
                {
                    var validateObject = schemaObjectDictionary[path];
                    xElement.Validate(validateObject, schemas,
                        (o, e) =>
                        {
                            if (!errorList.Contains(e.Message))
                                errorList.Add(e.Message);
                            if (e.Message.Contains("has incomplete content"))
                            {
                                if (!XElementsToDelete.Contains((XElement)o))
                                    XElementsToDelete.Add((XElement)o);
                            }
                            if (e.Message.Contains("has invalid child element"))
                            {
                                if (!XElementsInvalid.Contains((XElement)o))
                                    XElementsInvalid.Add((XElement)o);
                            }
                            if (e.Message.Contains("actual length is greater than the MaxLength value"))
                            {
                                if (!XElementsToCut.Contains((XElement)o))
                                    XElementsToCut.Add((XElement)o);
                            }
                        }, true);
                    if (xElement.HasElements)
                        ValidateElements(xElement.Elements().ToList(), schemaObjectDictionary, schemas,
                            schemaObjectDictionaryKeys, errorList);
                }
                else
                {
                    var log = $"The element '{xElement.Name.LocalName}' is unknown. It should be delete.";
                    if (!errorList.Contains(log))
                        errorList.Add(log);
                    if (XElementsInvalid.Contains(xElement))
                        XElementsInvalid.Remove(xElement);
                    if (XElementsToCut.Contains(xElement))
                        XElementsToCut.Remove(xElement);
                    if (!XElementsToDelete.Contains(xElement))
                        XElementsToDelete.Add(xElement);
                }
                if (schemaObjectDictionaryKeys.Count > 0)
                    schemaObjectDictionaryKeys.RemoveAt(schemaObjectDictionaryKeys.Count - 1);
            });
        }
