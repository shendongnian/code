    private void btnCheckCleared_Click(object sender, EventArgs e)
    {
        foreach (Transaction item in tranArray)
        {
            if (/*Whatever your condition looks like*/)
            {
                item.TransactionDate = item.TransactionDate.AddDays(3);
            }
        }
    }
