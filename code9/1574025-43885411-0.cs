    private void SetToolTipText(DataGridViewRow row, String message)
    {
            foreach (DataGridViewCell cell in row.Cells)
                cell.ToolTipText = message;
    }
    private void AddConnections()
    {
                int rowId = dgvConnections.Rows.Add(" --  row contents --");
                SetToolTipText(dgvConnections.Rows[rowId], "some tool-tip text");
    }
