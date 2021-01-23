            Table table = section.Headers.Primary.AddTable();
            table.AddColumn("11cm");
            table.AddColumn("2cm");
            table.AddColumn("8cm");
            
            Row row = table.AddRow();
            row.VerticalAlignment = VerticalAlignment.Center;
            Paragraph header = row.Cells[0].AddParagraph("Heading");
            header.Format.Font.Bold = true;                        
            Image image = row.Cells[1].AddImage("../../Images/logo.png");
            image.Height = Unit.FromMillimeter(6);
            row.Cells[2].AddParagraph("Title");
