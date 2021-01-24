    private void PrintOutMaxValues() 
    {
        int currentMax = 0;
        
        var input = new int[] { 3, 2, 5, 7, 1, 4, 4, 11, 3, 11, 11, 3 };
        var maxCounter = 0;
        // find max values
        for ( int inputIndex = 0; inputIndex < input.Length; inputIndex++) 
        {
            if ( input[ inputIndex ] > currentMax )
            {
               currentMax = input[ inputIndex ];
               maxCounter = 1;
            }
            else if ( input[ inputIndex ] == currentMax ) 
            {
               maxCounter++;
            }
        }
        
        //print out the maximum the number of times it occurred
        for ( var resultIndex = 0; resultIndex < maxCounter; resultIndex++) 
        {
            richTextBox1.Text += currentMax.ToString();
        }
    }
