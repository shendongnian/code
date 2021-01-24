    public bool VerifyRow(int pRowNum,string pValue)
    {
        foreach (DataGridViewCell cell in dgvInventory.Rows[pRowNum])
        {
            string currentItem = cell.Value.ToString();
            if (currentItem == pValue)
            {
                return false;
            }
        }
        return true;
    }
