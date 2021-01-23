    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        const int xMax = 10;
        const int yMax = 5;
        const int worstZMax = 99; //because upper is exclusive in Random.Next(lower, upper) 
    
        var iteration = 0;
        var total = xMax * yMax * worstZMax; //total number of iterations (worst case)
    
        for (var x = 1; x <= xMax; x++)
        {
            for (var y = 1; y <= yMax; y++)
            {
                var zMax = new Random().Next(50, 100);
    
                //get how many iterations did we miss, and adjust the total iterations
                total -= (99 - zMax);
                for (var z = 1; z <= zMax; z++)
                {
                    iteration++;  //count this iteration
                    Thread.Sleep(5); // The process
    
                    // The progress calculation
                    var progress = (double)iteration / total * pgb.Maximum;
    
                    bgw.ReportProgress((int)progress);
                }
            }
        }
    }
