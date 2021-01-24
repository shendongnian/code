    private void btnTitelRow2_Click(object sender, EventArgs e)
    {
        const int row = 1;
        fncLOITitelrow(row, CheckTitelStatus(row));
    }
    public bool CheckTitelStatus(int row)
    {
        Label[] Titelbl = getLOILabelTitel();
        return Titelbl[row].BackColor == System.Drawing.Color.LightGray;
    }
