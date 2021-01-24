    public bool VerifyRow(DataGridViewRow pRow,string pValue)
    {
        foreach (DataGridViewCell cell in pRow.Cells)
        {
            string currentItem = cell.Value.ToString();
            if (currentItem == pValue)
            {
                return false;
            }
        }
        return true;
    }
