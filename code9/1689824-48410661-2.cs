    for (int i = 0; i < 9; i++)
    { 
        if (ValidMove(i, gameState) {
            char[] clone = new char[gameState.Length];
            gameState.CopyTo(clone, 0);
            clone[i] = 'X';
            double score = MinPlay(clone);
            if (score > bestScore)
            {
                bestScore = score;
            }
        }
    }
    return bestScore;
