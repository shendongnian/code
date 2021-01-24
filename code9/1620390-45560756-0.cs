    private void listForm1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the value from the selected item
        string val = listForm1.SelectedItem.Value;
        // Split the item's value to a string array according to the pipe char
        string[] valArray = val.Split('|');
        // Convert the 3 numbers to int
        int num1 = Convert.ToInt32(valArray[1]);
        int num2 = Convert.ToInt32(valArray[2]);
        int num3 = Convert.ToInt32(valArray[3]);
        // Calculate the sum and the average. 
        // Keep in mind using an integer will create a whole number, without decimal points.
        int sum = num1 + num2 + num3;
        int average = sum / 3;
        // Place the average and the sum in textboxes
        txtAverage.Text = average.ToString();
        txtTotal.Text = sum.ToString();
    }
