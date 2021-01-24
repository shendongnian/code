    public static void SetColor(ref Table table)
    {
         Row t = table.Rows[1];
         foreach (Cell c in t.GetChildNodes(NodeType.Cell, true))
         {
              c.CellFormat.Shading.BackgroundPatternColor = Color.FromArgb(198, 217, 241);
         }
    }
