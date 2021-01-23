    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (GridView1.SelectedRows.Count == 0) return;
        vSelectedRow = GridView1.SelectedIndex;
        vWORKORDER_TYPE = GridView1.SelectedRow.Cells[1].Text;
        //vTYPE = GridView1.SelectedRow.Cells[1].Text;
        vWORKORDER_BASE_ID = GridView1.SelectedRow.Cells[2].Text;
        vWORKORDER_LOT_ID = GridView1.SelectedRow.Cells[3].Text;
        vWORKORDER_SPLIT_ID = GridView1.SelectedRow.Cells[4].Text;
        vWORKORDER_SUB_ID = GridView1.SelectedRow.Cells[5].Text;
        vOPERATION_SEQ_NO = Convert.ToInt32(GridView1.SelectedRow.Cells[6].Text);
        vRESOURCE_ID = GridView1.SelectedRow.Cells[7].Text;
        vHOURLY_COST = Convert.ToDecimal(GridView1.SelectedRow.Cells[9].Text);
        vUNIT_COST = Convert.ToDecimal(GridView1.SelectedRow.Cells[10].Text);
        vBURDEN_PER_HR = Convert.ToDecimal(GridView1.SelectedRow.Cells[11].Text);
        vBURDEN_PER_UNIT = Convert.ToDecimal(GridView1.SelectedRow.Cells[12].Text);
        vBURDEN_PERCENT = Convert.ToDecimal(GridView1.SelectedRow.Cells[13].Text);
        vBUR_PER_OPERATION = Convert.ToDecimal(GridView1.SelectedRow.Cells[14].Text);
 }
