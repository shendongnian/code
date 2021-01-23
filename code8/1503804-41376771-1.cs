         /*OpenXMLWriter to write large data to excel to avoid System.OutOfMemoryException*/
                    OpenXmlWriter oxw = OpenXmlWriter.Create(wsPart);
                    oxw.WriteStartElement(new Worksheet());
                   /*Excel column style */
                    oxw.WriteStartElement(new Columns());
                    foreach (var item in gridHeaderList)
                    {
                        oxw.WriteStartElement(new Column(), new List<OpenXmlAttribute>()
                        { new OpenXmlAttribute("min", null, (item.columnIndex + 1).ToString()),
                          new OpenXmlAttribute("max", null, (item.columnIndex + 1).ToString()),
                          new OpenXmlAttribute("width", null, item.columnWidth.ToString())
                        }
                        );
                        oxw.WriteEndElement();
                    }
                    oxw.WriteEndElement();
                    /*End of Columns element node*/
                    
                     /*Sheet data node*/
                    oxw.WriteStartElement(new SheetData());
                    
                    oxw.WriteStartElement(new Row());
                    foreach (var item in dataList)
                    {
                        oxw.WriteElement(new Cell() { CellValue = new CellValue(item.Value), DataType = CellValues.String, StyleIndex = item.styleIndex });
                    }
                    oxw.WriteEndElement();
                    
                    oxw.WriteEndElement();
                    /*End of sheetdata element node*/
                    /*Start of MergeCells element node NOTE: Make sure initialize "A6:D6" range cells         */      
         oxw.WriteStartElement(new MergeCells());
                        oxw.WriteElement(new MergeCell() { Reference = new StringValue("A6:D6") });
                        oxw.WriteEndElement();
                        /*End of MergeCells element node*/
                   
                    oxw.WriteEndElement();
                    /*End of worksheet element node*/
                    oxw.Close();
