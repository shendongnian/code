    // Example linear calculation
    public int Calculation(int a, int b, int c, int d, int e, int f)
    {
        int result = 0;
        unchecked
        {
            result = (int)((double)a * Math.Tan((double)b * Math.PI / ((double)c + 0.001)));
            result += d + e + f;
        }
        
        return result;
    }
    var rand = new Random();
    // The currently best known solution set
    var best = new int[6] { 1, 1, 1, 1, 1, 1 };
    // Score for best known solution set
    int bestScore = int.MinValue;
    // loop variables
    int score;
    var work = new int[6];
    // Loop as appropriate.
    for (int i=0; i<500; i++)
    {
        // Copy over the best solution to modify it
        best.CopyTo(work, 0);
        // Change one of the parameters of the best solution
        work[rand.Next() % 6] = rand.Next() % 101;
        // Calculate new score with modified solution
        score = Calculation(work[0], work[1], work[2], work[3], work[4], work[5]);
        // Only keep this solution if it's better than anything else
        if (score > bestScore)
        {
            work.CopyTo(best, 0);
            bestScore = score;
        }
    }
