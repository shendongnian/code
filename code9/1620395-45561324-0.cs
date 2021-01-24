    private void listForm1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the value from the selected item
        string val = listForm1.GetItemText(listForm1.SelectedItem);
    
        // Split the item's value to a string array according to the pipe char
        string[] valArray = val.Split('|');
    
        int sum = 0;
        int scores = 0;
        int value=0;
        // Iterate through all possible values and sum it up, 
        // while keeping count to how many numbers there are:
        for (int i = 1; i < valArray.Length; i++)
        {
    int.TryParse(valArray[i], out value);
    if(value>0){
              int num = value;
              sum += num;
              scores++;
    }
        }
    
        // Calculate the  average. 
        // Keep in mind using an integer will create a whole number, without decimal points.        
        int average = sum / scores;
    
        // Place the average and the sum in textboxes
        txtAverage.Text = average.ToString();
        txtTotal.Text = sum.ToString();
        txtCount.Text = scores.ToString();
    }
