    private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            neturalDataSet.centersDataTable table = new neturalDataSet.centersDataTable();
            centersTableAdapter.Fill(table);
            
            y = 80;
            itemperpage = 0;
            
                     
            _CurrentPageNumber++;
            if(_CurrentPageNumber != 1)
            {
                skip += 6;
            }
          
            var query = table.AsEnumerable().Skip(skip);
            foreach (DataRow row in query.CopyToDataTable().Rows)
            {
                e.Graphics.DrawString(row[0].ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, y, new StringFormat());
                y += 100;
                if (itemperpage < 5)
                {
                    itemperpage += 1;
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                    return;
                }
            }
                                                   
        }
