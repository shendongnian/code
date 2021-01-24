    //Global
        long[] sizes = new long[3]{0,0,0};
    //Function Call with column index as second parameter
                        addCell(firstRow,0, "First top line left", topLeft);
    
    //Function
                        private void addCell(TableRow tableRow,int column, string text, int position)
                        {
                            Size measure = TextRenderer.MeasureText(text, SystemFonts.DefaultFont);
                            if (measure.Width > sizes[column])
                            {
                               
                                sizes[column] = measure.Width;
                                mainTable.Columns[column].Width = new System.Windows.GridLength(measure.Width);
                            }
                            var run = new Run(text);
                            var tableCell = new TableCell(new Paragraph(run));
                            tableCell.BorderBrush = Brushes.Gray;
                            if (position == topLeft)
                            {
                                tableCell.BorderThickness = new Thickness(1, 1, 1, 1);
                            }
                            else if (position == topRight)
                            {
                                tableCell.BorderThickness = new Thickness(0, 1, 1, 1);
                            }
                            else if (position == left)
                            {
                                tableCell.BorderThickness = new Thickness(1, 0, 1, 1);
                            }
                            else if (position == right)
                            {
                                tableCell.BorderThickness = new Thickness(0, 0, 1, 1);
                            }
                            tableRow.Cells.Add(tableCell);
                        }
                    }
