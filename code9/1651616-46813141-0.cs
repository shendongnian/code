    private int occurrence; 
    private int data;
    private int previousData;
    private DateTime? switchToOne;
    private void MyTick(object sender, EventArgs e)
    {
        if (data == 1 && previousData == 0) // switch detected
        {
            switchToOne = DateTime.Now; // notice the time point when this happened
        }
        
        // if the current value is still 1
        // and a switch time has been noticed
        // and the "1" state lasts for more than 2 seconds
        if (data == 1 && switchToOne != null && (DateTime.Now - switchToOne.Value) >= TimeSpan.FromSeconds(2))
        {
            // then count that occurrence
            occurrence++;
            // and reset the noticed time in order to count this occurrence
            // only one time
            switchToOne = null;
        }
        previousData = data;
    }
