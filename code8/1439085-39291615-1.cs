    using ClosedXML.Excel;
    public void ExportToExcelWithFormatting()
    {
        string FileName;
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        saveFileDialog1.Title = "To Excel";
        saveFileDialog1.FileName = this.Text + " (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            FileName = saveFileDialog1.FileName;
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(this.Text);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].Name;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cell(i + 2, j + 1).Value = dataGridView1.Rows[i].Cells[j].Value.ToString();
 
                    if (worksheet.Cell(i + 2, j + 1).Value.ToString().Length > 0)
                    {
                        XLAlignmentHorizontalValues align;
                        switch (dataGridView1.Rows[i].Cells[j].Style.Alignment)
                        {
                            case DataGridViewContentAlignment.BottomRight:
                                align = XLAlignmentHorizontalValues.Right;
                                break;
                            case DataGridViewContentAlignment.MiddleRight:
                                align = XLAlignmentHorizontalValues.Right;
                                break;
                            case DataGridViewContentAlignment.TopRight:
                                align = XLAlignmentHorizontalValues.Right;
                                break;
                            case DataGridViewContentAlignment.BottomCenter:
                                align = XLAlignmentHorizontalValues.Center;
                                break;
                            case DataGridViewContentAlignment.MiddleCenter:
                                align = XLAlignmentHorizontalValues.Center;
                                break;
                            case DataGridViewContentAlignment.TopCenter:
                                align = XLAlignmentHorizontalValues.Center;
                                break;
                            default:
                                align = XLAlignmentHorizontalValues.Left;
                                break;
                        }
                        worksheet.Cell(i + 2, j + 1).Style.Alignment.Horizontal = align;
                            
                        XLColor xlColor = XLColor.FromColor(dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor);
                        worksheet.Cell(i + 2, j + 1).AddConditionalFormat().WhenLessThan(1).Fill.SetBackgroundColor(xlColor);
                        worksheet.Cell(i + 2, j + 1).Style.Font.FontName = dataGridView1.Font.Name;
                        worksheet.Cell(i + 2, j + 1).Style.Font.FontSize = dataGridView1.Font.Size;
                           
                    }                                           
                }
            }
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(FileName);
            MessageBox.Show("Done");
        }
    }
