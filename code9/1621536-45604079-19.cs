    private void listForm1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string val = listForm1.GetItemText(listForm1.SelectedItem);
        string[] valArray = val.Split('|');
        int sum = 0;
        int scores = 0;
        for (int i = 1; i < valArray.Length; i++)
        {
            int num = Convert.ToInt32(valArray[i]);
            sum += num;
            scores++;
        }
        int average = 0;
        if (scores != 0)
            average = sum / scores;
        txtAverage.Text = average.ToString();
        txtTotal.Text = sum.ToString();
        txtScoreCount.Text = scores.ToString();
    }
