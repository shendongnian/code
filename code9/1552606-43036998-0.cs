    private void btnTestConcatenations_Click(object sender, EventArgs e)
    {
        var testTimer = new Stopwatch();
        var strTest = string.Empty;
        var numOperations = NUMBER_CONCATENATIONS_TO_PERFORM;
        // Start the stopwatch
        testTimer.Start();
        
        // Do some operation that you want to measure
        for (int loopcount = 0; loopcount < numOperations; loopcount++)
        {
            strTest += "Adding 20 characters";
        }
        // Stop the stopwatch
        testTimer.Stop();
        var elapsedTime = testTimer.Elapsed;
        // Do something with the stopwatch results
        MessageBox.Show($"It took {elapsedTime} seconds to do {numOperations} concatenations");
    }
