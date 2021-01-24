            var table = PdfWriter.CreateTable(9);
			table.SetWidths(new[] { 0.3f, 1.7f, 3f, 1f, 1f, 1f, 1f, 1f, 1f });
			var cells =
				from line in lines
				let values = new[]
				{
					new { Text = string.Empty, ColSpan = 1, Align = "<set value>" },
					new { Text = line.Description, ColSpan = 6, Align = "<set value>" },
					new { Text = string.Empty, ColSpan = 1, Align = "<set value>" },
					new { Text = FormatDecimal.Format(Math.Abs(line.Amount)), ColSpan = 1, Align = "<set value>"}
				}
				from value in values
				select new Cell
				{
					Grey = true,
					FontSize = "<set value>",
					HorizontalAlignment = value.Align,
					ColSpan = value.ColSpan,
					Text = value.Text
				};
			cells.ForEach(table.AddCell);
				
			var position = new Position(PdfWriter.DocLeft, PdfWriter.DocTop - 20 - 245);
			table.TotalWidth = PdfWriter.DocRight - PdfWriter.DocRightMargin;
            table.LockedWidth = "<set value>";
            table.WriteSelectedRows(0, -1, position.HorizontalPosition, position.VerticalPosition, Writer.DirectContent);
