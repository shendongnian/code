    class Program
    {
        static void  Main(string[] args)
        {
            Document doc = new Document();
            Section s = doc.AddSection();
            Table table = s.AddTable(true);
            //Create Header and Data
            String[] header = { "Item", "Description", "Qty", "Unit Price", "Price" };
            String[][] data = {
                                  new String[]{ "Spire.Doc for .NET",".NET Word Component","1","$799.00","$799.00"},
                                  new String[]{"Spire.XLS for .NET",".NET Excel Component","2","$799.00","$1,598.00"},
                                  new String[]{"Spire.Office for .NET",".NET Office Component","1","$1,899.00","$1,899.00"},
                                  new String[]{"Spire.PDF for .NET",".NET PDFComponent","2","$599.00","$1,198.00"},
                              };
            //Add Cells
            table.ResetCells(data.Length + 1, header.Length);
            //Header Row
            TableRow fRow = table.Rows[0];
            fRow.IsHeader = true;
            //Row Height
            fRow.Height = 23;
            //Header Format
            fRow.RowFormat.BackColor = Color.AliceBlue;
            for (int i = 0; i < header.Length; i++)
            {
                //Cell Alignment
                Paragraph p = fRow.Cells[i].AddParagraph();
                fRow.Cells[i].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                p.Format.HorizontalAlignment = HorizontalAlignment.Center;
                //Data Format
                TextRange TR = p.AppendText(header[i]);
                TR.CharacterFormat.FontName = "Calibri";
                TR.CharacterFormat.FontSize = 14;
                TR.CharacterFormat.TextColor = Color.Teal;
                TR.CharacterFormat.Bold = true;
            }
            //Data Row
            for (int r = 0; r < data.Length; r++)
            {
                TableRow dataRow = table.Rows[r + 1];
                //Row Height
                dataRow.Height = 20;
                //C Represents Column.
                for (int c = 0; c < data[r].Length; c++)
                {
                    //Cell Alignment
                    dataRow.Cells[c].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    //Fill Data in Rows
                    Paragraph p2 = dataRow.Cells[c].AddParagraph();
                    TextRange TR2 = p2.AppendText(data[r][c]);
                    //Format Cells
                    p2.Format.HorizontalAlignment = HorizontalAlignment.Center;
                    TR2.CharacterFormat.FontName = "Calibri";
                    TR2.CharacterFormat.FontSize = 12;
                    TR2.CharacterFormat.TextColor = Color.Brown;
                }
            }
            //Save and Launch
            doc.SaveToFile("WordTable.docx", FileFormat.Docx2013);
            System.Diagnostics.Process.Start("WordTable.docx");
            Console.ReadLine();
        }
