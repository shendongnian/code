    int countResults;
    private void btnGo_Click(object sender, System.EventArgs e)
    {
        // Assign item count value
        countResults = dataRepeater1.ItemCount;
        if (countResults != 0)
        {
            for (int i = 0; i < countResults; i++)
            {
                dataRepeater1.RemoveAt(i);                    
            }
        }        
    }
