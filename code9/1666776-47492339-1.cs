    int formulaCol = dataGridView2.Columns.Count + 1;
    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
    {
        for (int j = 0; j < dataGridView2.Columns.Count; j++)
        {
            worksheet.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
        }
        worksheet.Cells[i + 2, formulaCol].FormulaR1C1 = "=R[0]C[-2]*2";
    }
