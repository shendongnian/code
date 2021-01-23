    Worksheet sheet = Globals.ThisAddIn.Application.ActiveSheet;
    Range rng = sheet.UsedRange;
    foreach (Range column in from Range row in rng.Rows from Range column in row.Columns where column.Value == "T" select column)
    {
       column.Interior.Color = Color.Red;
    }
