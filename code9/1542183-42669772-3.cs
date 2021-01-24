    private void UpdateBalance()
    {
        for (int i = 0; i < dgview2.Rows.Count; i++)
        {
            int credit1, debit1, balance;
            if (int.TryParse(dgview2.Rows[i].Cells[3].Value.ToString(),
                    out debit1) && int.TryParse(dgview2.Rows[i].Cells[4].Value.ToString(),
                    out credit1) && int.TryParse(dgview2.Rows[i].Cells[5].Value.ToString(),
                    out balance))
            {
                balance = balance + credit1 - debit1;
                dgview2.Rows[i].Cells["balance"].Value = balance.ToString();
            }
                
        }
    }
