    List<CellName> cells = null;
    foreach(XElement element in vsDataEUtranCellFDD)
    {
       CellName newCell = new CellName();
       cells.Add(newCell);
       newCell.id = (string)element.Attribute("id");
       XElement attribute = element.Descendants().Where(a => a.Name.LocalName == "attribute").FirstOrDefault;
       newCell.earfcndl = (int)attribute.Elements().Where(a => a.Name.LocalName == "earfcndl").FirstOrDefault(),
       newCell.earfcnul = (int)attribute.Elements().Where(a => a.Name.LocalName == "earfcnul").FirstOrDefault()
     }
