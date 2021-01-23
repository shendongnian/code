    do
    {
            if (sdr.HasRows)
            {
            int itm = (Int32)sdr["Sale_Invoice_No"];
            int inovice = (Int32)sdr["Item_Code"];
            double ptype = (double)sdr["Item_Payable_Amount"];
            int qnty = (Int32)0;
            ////NOW, POPULATE THE DATA INTO THE CELLS
            int n = dgv.Rows.Add(sdr);
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = itm;
                dataGridView1.Rows[i].Cells[1].Value = itm;
                dataGridView1.Rows[i].Cells[2].Value = ptype;
                dataGridView1.Rows[i].Cells[3].Value = qnty;
                
             }
        
            }
    } while (sdr.NextResult());
    con.Close();
