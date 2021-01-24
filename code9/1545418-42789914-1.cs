                // <Fills>
            Fill fill1 = new Fill(
                new PatternFill(
                    new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "DCDCDC" } }
                )
                { PatternType = PatternValues.Solid });
            Fills fills = new Fills(
                new Fill(new PatternFill() { PatternType = PatternValues.None }), //this is what it will be REGARDLESS of what you set it to
                new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), //this is what it will be REGARDLESS of what you set it to
                fill1);
            // <Borders>
            Border border0 = new Border();     // Default border
            Borders borders = new Borders();    // <APPENDING Borders>
            borders.Append(border0);
            CellFormat _0_default = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 }; // Default style : Mandatory | Style ID =0
            CellFormat _1_header = new CellFormat() { FontId = 1, FillId = 2, ApplyFill = true }; //HEADER
