    private static string CalculateMinimumEdit(string[] original, string[] final)
    {
        int[,] costs = new int[original.Length + 1, final.Length + 1];
            
        // =, +, - or * for equal words, inserted, deleted or modified word
        char[,] resultOf = new char[original.Length + 1, final.Length + 1];
        // Set all costs to invalid values (mark all positions not reached)
        InitializeInvalidCosts(costs);
        // Empty sequences are equal and their edit costs is 0
        // This is setting the initial state for the following calculation
        resultOf[0, 0] = '=';
        costs[0, 0] = 0;
        for (int originalIndex = 0; originalIndex < original.Length + 1; originalIndex++)
        {
            for (int finalIndex = 0; finalIndex < final.Length + 1; finalIndex++)
            {
                SetDeleteCost(costs, resultOf, originalIndex, finalIndex);
                SetInsertCost(costs, resultOf, originalIndex, finalIndex);
                SetModifiedCost(costs, resultOf, originalIndex, finalIndex);
                SetEqualCost(costs, resultOf, originalIndex, finalIndex, original, final);
            }
        }
        return ReconstructEdit(costs, resultOf, original, final);
    }
    private static void InitializeInvalidCosts(int[,] costs)
    {
        // Set all costs to negative values
        // That will indicate that none of the positions
        // in the costs matrix has been analyzed yet
        for (int i = 0; i < costs.GetLength(0); i++)
        {
            for (int j = 0; j < costs.GetLength(1); j++)
            {
                costs[i, j] = -1;
            }
        }
    }
    private static void SetInsertCost(int[,] costs, char[,] resultOf, 
                                        int originalIndex, int finalIndex)
    {
        // You can always assume that the new word was inserted
        // Position in original sequence remains the same
        // Position in final sequence moves by one and that is the new word
        // Cost of this change is 1
        SetCostIfBetter(costs, resultOf, originalIndex, finalIndex + 1,
                        costs[originalIndex, finalIndex] + 1, '+');
    }
    private static void SetDeleteCost(int[,] costs, char[,] resultOf,
                                        int originalIndex, int finalIndex)
    {
        // You can always assume that one word was deleted from original sequence
        // Position in original sequence moves by one and that is the deleted word
        // Position in final sequence remains the same
        // Cost of this change is 1
        SetCostIfBetter(costs, resultOf, originalIndex + 1, finalIndex,
                        costs[originalIndex, finalIndex] + 1, '-');
    }
    private static void SetModifiedCost(int[,] costs, char[,] resultOf,
                                        int originalIndex, int finalIndex)
    {
        // You can always assume that one word was replaced with another
        // Both positions in original and final sequences move by one
        // That means that one word from input was consumed
        // and it was replaced by a new word from the final sequence
        // Cost of this change is 1
        SetCostIfBetter(costs, resultOf, originalIndex + 1, finalIndex + 1,
                        costs[originalIndex, finalIndex] + 1, '*');
    }
    private static void SetEqualCost(int[,] costs, char[,] resultOf,
                                        int originalIndex, int finalIndex,
                                        string[] original, string[] final)
    {
        // If incoming words in original and final sequence are the same
        // then you can take advantage and move to the next position
        // at no cost
        // Position in original sequence moves by 1
        // Position in final sequence moves by 1
        // Cost of this change is 0
        if (originalIndex < original.Length &&
            finalIndex < final.Length &&
            original[originalIndex] == final[finalIndex])
        {
            // Attempt to set new cost only if incoming words are equal
            SetCostIfBetter(costs, resultOf, originalIndex + 1, finalIndex + 1,
                            costs[originalIndex, finalIndex], '=');
        }
    }
    private static void SetCostIfBetter(int[,] costs, char[,] resultOf,
                                        int originalIndex, int finalIndex,
                                        int cost, char operation)
    {
        // If destination cost is not set (i.e. it is negative)
        // or destination cost is non-negative but new cost is lower than that
        // then the cost can be set to new value and 
        // new operation which has caused the change can be indicated
        if (IsBetterCost(costs, originalIndex, finalIndex, cost))
        {
            costs[originalIndex, finalIndex] = cost;
            resultOf[originalIndex, finalIndex] = operation;
        }
    }
    private static bool IsBetterCost(int[,] costs, int originalIndex, 
                                        int finalIndex, int cost)
    {
        // New cost is better than existing cost if
        // either existing cost is negative (not set), 
        // or new cost is lower
        return
            originalIndex < costs.GetLength(0) && 
            finalIndex < costs.GetLength(1) &&
            (costs[originalIndex, finalIndex] < 0 ||
                cost < costs[originalIndex, finalIndex]);
    }
    private static string ReconstructEdit(int[,] costs, char[,] resultOf,
                                            string[] original, string[] final)
    {
        string edit = string.Empty;
        int originalIndex = original.Length;
        int finalIndex = final.Length;
        string space = string.Empty;
        while (originalIndex > 0 || finalIndex > 0)
        {
            edit = space + edit;
            space = " ";
            char operation = resultOf[originalIndex, finalIndex];
            switch (operation)
            {
                case '=':
                    originalIndex -= 1;
                    finalIndex -= 1;
                    edit = original[originalIndex] + edit;
                    break;
                case '*':
                    originalIndex -= 1;
                    finalIndex -= 1;
                    edit = final[finalIndex].ToUpper() + edit;
                    break;
                case '+':
                    finalIndex -= 1;
                    edit = final[finalIndex].ToUpper() + edit;
                    break;
                case '-':
                    originalIndex -= 1;
                    edit = "[" + original[originalIndex] + "]" + edit;
                    break;
            }
        }
        return edit;
    }
