    var ws = pck.Workbook.Worksheets.First();
    using (var namedRange = pck.Workbook.Names["MyNamedRange"])
          {
            for (int rowIndex = namedRange.Start.Row; rowIndex <= namedRange.End.Row; rowIndex++)
            {
              for (int columnIndex = namedRange.Start.Column; columnIndex <= namedRange.End.Column; columnIndex++)
              {
                ws.Cells[rowIndex, columnIndex].Value = 66;
              }
            }
          }
