    using System;
    using System.Linq;
    using System.Xml.Linq;
    using Word = NetOffice.WordApi;
    namespace TableTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    using (var app = Word.Application.GetActiveInstance())
                    {
                        var document = app.ActiveDocument;
                        var documentTitle = $"* Tables in {document.Name} *";
                        Console.WriteLine(new string('*', documentTitle.Length));
                        Console.WriteLine(documentTitle);
                        Console.WriteLine(new string('*', documentTitle.Length));
                        Console.WriteLine();
                        for (int i = 1; i <= document.Tables.Count; i++)
                        {
                            var table = document.Tables[i];
                            var tableTitle = $"Table #{i}";
                            Console.WriteLine(tableTitle);
                            Console.WriteLine(new string('-', tableTitle.Length));
                            foreach (var cellInfo in CellInfo.GetInfosFromTable(table))
                            {
                                Console.WriteLine(" - " + cellInfo);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.WriteLine();
                Console.WriteLine("Done executing!");
                Console.ReadLine();
            }
            class CellInfo
            {
                public Word.Cell Cell { get; set; }
                public XElement XmlCell { get; set; }
                public int XmlRow { get; set; }
                public int XmlColumn { get; set; }
                public int Row { get; set; }
                public int Column { get; set; }
                public XElement MergedHorizontallyWith { get; set; }
                public XElement MergedVerticallyWith { get; set; }
                public override string ToString()
                {
                    if (MergedHorizontallyWith == null && MergedVerticallyWith == null)
                    {
                        var range = Cell?.Range;
                        var interopText = string.Empty;
                        if (!Equals(range, null))
                        {
                            interopText = range.Text;
                            //\r\a marks the end of a cell, \r and \n are normal line breaks
                            interopText = interopText.Replace("\r\a", "<>").Replace("\r", "\\r").Replace("\n", "\\n");
                            //Remove the last cell ending marker (it's always there)
                            if (interopText.EndsWith("<>"))
                                interopText = interopText.Substring(0, interopText.Length - 2);
                        }
                        return $"xml: {Row}, {Column} (interop: {XmlRow}, {XmlColumn}): {XmlCell?.Value ?? string.Empty} = {interopText}";
                    }
                    else if (MergedHorizontallyWith != null)
                    {
                        return $"xml: {Row}, {Column} (interop: {XmlRow}, {XmlColumn}): MERGED HORIZONTALLY";
                    }
                    else if (MergedVerticallyWith != null)
                    {
                        return $"xml: {Row}, {Column} (interop: {XmlRow}, {XmlColumn}): MERGED VERTICALLY";
                    }
                    else
                    {
                        return $"xml: {Row}, {Column} (interop: {XmlRow}, {XmlColumn}): this shouldn't happen";
                    }
                }
                public static CellInfo[,] GetInfosFromTable(Word.Table table)
                {
                    var doc = XDocument.Parse(table.Range.XML);
                    CellInfo[,] cellInfos = GetInitializedArray(table);
                    var xmlTable = doc.Descendants().First(n => n.Name.LocalName == "tbl");
                    var rows = xmlTable.Elements().Where(e => e.Name.LocalName == "tr").ToArray();
                    for (int r = 0; r < rows.Length; r++)
                    {
                        var row = rows[r];
                        var rowCells = row.Elements().Where(e => e.Name.LocalName == "tc").ToArray();
                        var c = 0;
                        foreach (var rowCell in rowCells)
                        {
                            cellInfos[r, c].XmlCell = rowCell;
                            cellInfos[r, c].XmlRow = r;
                            cellInfos[r, c].XmlColumn = c;
                            var gridSpan = int.Parse(rowCell.Descendants().FirstOrDefault(d => d.Name.LocalName == "gridSpan")?.Attributes().FirstOrDefault(a => a.Name.LocalName == "val")?.Value ?? "1");
                            if (gridSpan > 1)
                            {
                                for (int i = 1; i < gridSpan; i++)
                                {
                                    cellInfos[r, c + i].MergedHorizontallyWith = rowCell;
                                    cellInfos[r, c + i].XmlRow = r;
                                    cellInfos[r, c + i].XmlColumn = c + i;
                                }
                            }
                            c += gridSpan;
                        }
                    }
                    ApplyVerticalMerges(cellInfos);
                    FindCorrespondingInteropCells(table, cellInfos);
                    return cellInfos;
                }
                private static CellInfo[,] GetInitializedArray(Word.Table table)
                {
                    var cellInfos = new CellInfo[table.Rows.Count, table.Columns.Count];
                    for (int r = 0; r < cellInfos.GetLength(0); r++)
                    {
                        for (int c = 0; c < cellInfos.GetLength(1); c++)
                        {
                            cellInfos[r, c] = new CellInfo();
                        }
                    }
                    return cellInfos;
                }
                private static void ApplyVerticalMerges(CellInfo[,] cellInfos)
                {
                    for (int r = 0; r < cellInfos.GetLength(0); r++)
                    {
                        for (int c = 0; c < cellInfos.GetLength(1); c++)
                        {
                            var cellInfo = cellInfos[r, c];
                            var vmerge = cellInfo.XmlCell?.Descendants().FirstOrDefault(d => d.Name.LocalName == "vmerge");
                            if (vmerge != null)
                            {
                                var isParent = (vmerge.Attributes().FirstOrDefault(a => a.Name.LocalName == "val")?.Value ?? string.Empty) == "restart";
                                if (isParent)
                                {
                                    MarkCellsBelow(cellInfos, r, c);
                                }
                            }
                        }
                    }
                }
                private static void MarkCellsBelow(CellInfo[,] cells, int parentR, int parentC)
                {
                    var parentCell = cells[parentR, parentC];
                    for (int r = parentR + 1; r < cells.GetLength(1); r++)
                    {
                        var cell = cells[r, parentC];
                        var vmerge = cell.XmlCell?.Descendants().FirstOrDefault(d => d.Name.LocalName == "vmerge");
                        if (vmerge == null) break;
                        var isParent = (vmerge?.Attributes().FirstOrDefault(a => a.Name.LocalName == "val")?.Value ?? string.Empty) == "restart";
                        if (isParent) break;
                        cell.MergedVerticallyWith = parentCell.XmlCell;
                    }
                }
                private static void FindCorrespondingInteropCells(Word.Table table, CellInfo[,] cellInfos)
                {
                    var interopRow = 1;
                    for (int r = 0; r < cellInfos.GetLength(0); r++)
                    {
                        var interopCol = 0;
                        for (int c = 0; c < cellInfos.GetLength(1); c++)
                        {
                            var cellInfo = cellInfos[r, c];
                            if (cellInfo.MergedVerticallyWith != null)
                            {
                                interopCol++;
                            }
                            else
                            {
                                interopCol++;
                                cellInfo.Row = interopRow;
                                cellInfo.Column = interopCol;
                                cellInfo.Cell = GetCell(cellInfo, table);
                            }
                        }
                        interopRow++;
                    }
                }
                private static Word.Cell GetCell(CellInfo cellInfo, Word.Table table)
                {
                    foreach (var cell in table.Range.Cells)
                    {
                        if (cell.NestingLevel == table.NestingLevel)
                        {
                            if (cellInfo.Column == cell.ColumnIndex && cellInfo.Row == cell.RowIndex)
                            {
                                return cell;
                            }
                        }
                    }
                    return null;
                }
            }
        }
    }
