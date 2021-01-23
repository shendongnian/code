    Table signOfftbl = doc.AddTable(4, 2);
    signOfftbl.Design = TableDesign.TableGrid;
    signOfftbl.Rows[0].Cells[0].Paragraphs.First().AppendLine("");
    signOfftbl.Rows[0].Cells[0].Width = 50m;
    signOfftbl.Rows[0].Cells[1].Paragraphs.First().AppendLine("Accept advice and action recommendations");
    signOfftbl.Rows[0].Cells[0].Width = 900m;
