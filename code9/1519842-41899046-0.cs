    public void selectAllCells(Worksheet activeSheet)
    {
        activeSheet.get_Range("a1").EntireRow.EntireColumn.Select();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        selectAllCells([..you need to add your active sheet here somehow..]);
    }
