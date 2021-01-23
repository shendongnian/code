     XElement XmlExp = new XElement("StockItems",
                                            from stock in DAL.GetEquipmentStockSummary()
                                            select new XElement("Item",
                                                                 new XAttribute("ID", stock.EquipmentStockID),
                                                                 new XElement("Tag", stock.TagNum),
                                                                 new XElement("Model", stock.SubGroup),
                                                                 new XElement("Desc", stock.Description),
                                                                 new XElement("Material", stock.Finish),
                                                                 new XElement("Condition", stock.isUsed ? "Refurbished" : "New"),
                                                                 new XElement("Location", stock.LocationName)
                                                                 )
                                          );
            context.Response.Headers.Add("Content-Disposition", "attachment;filename='SOHList.xml'");
            context.Response.ContentType = "text/xml";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            XmlExp.Save(context.Response.Output);
            context.Response.End();
