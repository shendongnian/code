            var items = selProject.Descendants("BOQ")
                                  .Where(boq => boq.Attribute("Division").Value == lbxDivision.Text)
                                  .Descendants("Item")
                                  .Select(itm => new BOQItem()
                                  {
                                       Code        = itm.Elements("Code")       .FirstOrDefault().Value,
                                       Description = itm.Elements("Description").FirstOrDefault().Value,
                                       Quantity    = itm.Elements("Quantity")   .FirstOrDefault().Value,
                                       Unit        = itm.Elements("Unit")       .FirstOrDefault().Value
                                  }).ToList();
