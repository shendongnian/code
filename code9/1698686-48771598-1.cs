        int sTotal = 0;
        int Average = 0;
        for(int i = 0; i < lstScores.Items.Count; i++)
        {
             bool result = Int16.TryParse(lstScores.Items[i],out int res);
             if (result)
             {
                sTotale += res;        
             }
        }
        Average = sTotal / lstScores.Items.Count;
        txtScoreTotal.Text = Convert.ToString(sTotal);
