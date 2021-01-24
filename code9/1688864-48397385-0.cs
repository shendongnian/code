    public void Column_Validating(DataGridView dataGridView)
        {
            decimal num;
            if (dataGridView.ColumnCount > 3)
            {
                for (int h = 4; h < dataGridView.ColumnCount; h++)
                {
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        if (!Decimal.TryParse(dataGridView[h, i].Value.ToString(), out num))
                        {
                            if (dataGridView[h, i].Value.ToString() == null || dataGridView[h, i].Value.ToString() == "") { }
                            else
                            {
                                MessageBox.Show("Row not decimal:" + " [ " + dataGridView[h, i].Value.ToString() + "] in column "  + dataGridView.Columns[h].Name);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int h = 3; h < dataGridView.ColumnCount; h++)
                {
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                       
                        if (!Decimal.TryParse(dataGridView[h, i].Value.ToString(), out num))
                        {
                            if (dataGridView[h, i].Value.ToString() == null || dataGridView[h, i].Value.ToString() == "") { }
                            else
                            {
                                MessageBox.Show("KEK " + dataGridView[h, i].Value.ToString());
                            }
                        }
                    }
                }
            }
        }
