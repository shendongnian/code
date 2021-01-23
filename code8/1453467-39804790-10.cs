    void moveBoxes(int count, string curMove, List<string> curMoveList, List<string> solutions)
    {
        // test for halting conditions:
        // 1) count == 0: we're done with this solution
        if (count == 0)
        {
            solutions.Add(curMove);
            return;
        }
        // 2) less than three boxes: invalid solution:
        else if (count < 3)
        {
            curMoveList.Remove(curMove);
            return;
        }
        // keep moving..:
        foreach (string cm in curMoveList)
            foreach (string k in fullMoves.Keys)
            {
                int bc = count - fullMoves[k];
                moveBoxes( bc, curMove + k,  curMoveList, solutions );
            }
    }
