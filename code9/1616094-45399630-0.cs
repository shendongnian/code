    private void checkorderstatus()
    {
        bool Unreceived = true;
        bool complete = true;
        if (dgvReceivedproducts.Rows.Count == Convert.ToInt32(rrQty.Text))
        {
            foreach (DataGridViewRow rw in dgvReceivedproducts.Rows)
            {
                string state = rw.Cells[dgvReceivedproducts.Columns["Status"].Index].Value.ToString();
                if (!state.Equals("Complete"))
                {
                    complete = false;
                    if (!state.Equals("Unreceived"))
                    {
                        Unreceived = false ;
                    }
                    break;
                }
            }
        
            if (complete)
            {
                crud.AddRecord("Update Orders Set Status  = 'Complete Order'  where OrderID = '" + rrorderid.Text + "'  ");
            }else if (Unreceived)
            {
                crud.AddRecord("Update Orders Set Status  = 'Unreceived'  where OrderID = '" + rrorderid.Text + "'  ");
            }else 
            {
                crud.AddRecord("Update Orders Set Status  = 'Back Order'  where OrderID = '" + rrorderid.Text + "'  ");
            }
        }
    }
