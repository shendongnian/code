    protected void TheLogic(string txt)
    {
       var row = dTable.Rows[currentRow];
        var ans = row["ANSWER"].ToString();
        if (txt == ans)
        {
        scoreAdd();
        MessageBox.Show("Correct");
        }
        else
        {
        MessageBox.Show(ans);
        }
        currentRow++;
        nextRow();
    }
