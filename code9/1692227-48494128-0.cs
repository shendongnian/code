     public void Validate_KPI(DataGridView dataGridView)
        {
            FileStream fs = new FileStream(@"C:\brandon\InvalidKPI.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            StringBuilder sb = new StringBuilder();
            decimal num;
            if (dataGridView.ColumnCount > 2)
            {
                int h = 2;
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        if (!Decimal.TryParse(dataGridView[h, i].Value.ToString(), out num))
                        {
                            if (dataGridView[h, i].Value.ToString() == "Revenue" || dataGridView[h, i].Value.ToString() == "Sales Volume" || dataGridView[h, i].Value.ToString() == "Gross Con" || dataGridView[h, i].Value.ToString() == "Brand Con")
                            {
                                sb.AppendLine(dataGridView[h, i].Value.ToString() + " is Valid");
                            }
                            else
                            {
                                //MessageBox.Show("Row not decimal:" + " [ " + dataGridView[h, i].Value.ToString() + "] in column "  + dataGridView.Columns[h].Name);
                                sb.AppendLine(dataGridView[h, i].Value.ToString() + " is not valid.");
                            }
                        }
                    }
            }
            sw.WriteLine(sb.ToString());
            MessageBox.Show(sb.ToString());
            Process.Start(@"C:\brandon\InvalidKPI.txt");
            sw.Flush();
            sw.Close();
        }
