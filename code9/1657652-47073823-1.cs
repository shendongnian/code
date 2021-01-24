    public static void CompareDataGridColumnForward(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                for (int i = dgv1.RowCount - 1; i >= 0; i--)
                {
                    for (int j = 0; j < dgv2.RowCount - 1; j++)
                    {
                        string dgv1value = dgv1.Rows[i].Cells[0].Value.ToString();
                        foreach (DataGridViewRow row in dgv2.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == dgv1value)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public static void CompareDataGridColumnReverse(DataGridView dgv1, DataGridView dgv2)
        {
            try
            {
                for (int i = dgv2.RowCount - 1; i >= 0; i--)
                {
                    for (int j = 0; j < dgv2.RowCount - 1; j++)
                    {
                        string dgv2value = dgv2.Rows[i].Cells[0].Value.ToString();
                        foreach (DataGridViewRow row in dgv1.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == dgv2value)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        } 
