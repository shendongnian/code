       public void Validate_Month(DataGridView dataGridView, int month, int select)
        {
            decimal num;
            StringBuilder sb =new StringBuilder();
            if (dataGridView.ColumnCount > 3)
            {
                for (int h = select; h <= month; h++)
                {
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        if (!Decimal.TryParse(dataGridView[h, i].Value.ToString(), out num))
                        {
                            if (dataGridView[h, i].Value.ToString() == null || dataGridView[h, i].Value.ToString() == "")
                            {
                            }
                            else
                            {
                                sb.AppendLine("Row not decimal:" + " [ " + dataGridView[h, i].Value.ToString() + "] in column " + dataGridView.Columns[h].Name);
                            }
                        }
                    }
                }
            }
            MessageBox.Show(sb.ToString());
        }
