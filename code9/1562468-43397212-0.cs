    foreach (DataGridViewRow row in tradeGridView.Rows)
    {
            for (int i = 0; i < tradeGridView.SelectedColumns.Count; i++)
            {
                //INDEX
                var index = tradeGridView.SelectedColumns[i].Index;
                //VALUE
                var value = row[index]
            }
    }
