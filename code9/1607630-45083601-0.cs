                    PDPage page = (PDPage)doc.getDocumentCatalog().getPages().get(pageNum);
                    PDResources resources = page.getResources();
                    PDFStreamParser parser = new PDFStreamParser(page);
                    parser.parse();
                    java.util.Collection tokens = parser.getTokens();
                    java.util.List newTokens = new java.util.ArrayList();
                    List<Tuple<int, int>> deletionIndexList = new List<Tuple<int, int>>();
                    object[] tokensArray = tokens.toArray();
                    for (int index = 0; index < tokensArray.Count(); index++)
                    {
                        object obj = tokensArray[index];
                        if (obj is COSName && (((COSName)obj) == COSName.OC))
                        {
                            int startIndex = index;
                            index++;
                            if (index < tokensArray.Count())
                            {
                                obj = tokensArray[index];
                                if (obj is COSName)
                                {
                                    PDPropertyList prop = resources.getProperties((COSName)obj);//Check if the COSName found is the resource name of layer which contains the markup to be deleted.
                                    if (prop != null && (prop is PDOptionalContentGroup))
                                    {
                                        if (((PDOptionalContentGroup)prop).getName() == markupLayerName)
                                        {
                                            index++;
                                            if (index < tokensArray.Count())
                                            {
                                                obj = tokensArray[index];
                                                if (obj is Operator && ((Operator)obj).getName() == "BDC")//Check if the token specifies the start of markup
                                                {
    
                                                    int endIndex = -1;
                                                    index++;
                                                    while (index < tokensArray.Count())
                                                    {
                                                        obj = tokensArray[index];
                                                        if (obj is Operator && ((Operator)obj).getName() == "EMC")//Check if the token specifies the end of markup
                                                        {
                                                            endIndex = index;
                                                            break;
                                                        }
                                                        index++;
                                                    }
                                                    if (endIndex >= 0)
                                                    {
                                                        deletionIndexList.Add(new Tuple<int, int>(startIndex, endIndex));
                                                    }
                                                }
    
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    int tokensListIndex = 0;
                    for (int index = 0; index < deletionIndexList.Count(); index++)
                    {
                        Tuple<int, int> indexes = deletionIndexList.ElementAt(index);
                        while (tokensListIndex < indexes.Item1)
                        {
                            newTokens.add(tokensArray[tokensListIndex]);
                            tokensListIndex++;
                        }
                        tokensListIndex = indexes.Item2 + 1;
                    }
                    while (tokensListIndex < tokensArray.Count())
                    {
                        newTokens.add(tokensArray[tokensListIndex]);
                        tokensListIndex++;
                    }
                    PDStream newContents = new PDStream(doc);
                    OutputStream output = newContents.createOutputStream(COSName.FLATE_DECODE);
                    ContentStreamWriter writer = new ContentStreamWriter(output);
                    writer.writeTokens(newTokens);
                    output.close();
                    page.setContents(newContents);
