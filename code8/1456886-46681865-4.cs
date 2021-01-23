     List<CellName> cells = new List<CellName>(); ;
                                                foreach (XElement xelement in vsDataEUtranCellFDD)
                                                {
                                                    CellName newCell = new CellName();
                                                    newCell.id = (string)xelement.Attribute("id");
                                                    XElement attribute = xelement.Descendants().Where(a => a.Name.LocalName == "vsDataEUtranCellFDD").FirstOrDefault();
                                                    newCell.earfcndl = (int?)attribute.Elements().Where(a => a.Name.LocalName == "earfcndl").FirstOrDefault();
                                                    newCell.earfcnul = (int)attribute.Elements().Where(a => a.Name.LocalName == "earfcnul").FirstOrDefault();
            cells.Add(newCell);
         }
    }
