private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
    DataGridView dgv = (DataGridView)sender;
    
        //use index in your gridView
        if (dgv.Columns[e.ColumnIndex] == 2)
        {
            //vHisOrd_BtnDelivered    
        }
        else if (dgv.Columns[e.ColumnIndex] == 3)
        {
            //vOrdHis_Btn
        }
}
