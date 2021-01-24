    /// <summary>
                /// Ensure all numbers in the spiral have thesame number of digits
                /// </summary>
                /// <param name="curr">The current numbers to be added to the spiral</param>
                /// <param name="n">The number the user entered</param>
                /// <returns></returns>
    public static string CheckCurrent(int curr, int n)
        {
            int lenMaxNum = (n * n).ToString().Length;
            int lenCurr = curr.ToString().Length;
    
            string current = curr.ToString();
    
            int dif = lenMaxNum - lenCurr;
    
        for (int i = 0; i < dif; i++)
        {
            current = "0" + current;
        }
    
        return current;
    }
