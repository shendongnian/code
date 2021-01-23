    void fullMove(int count, string curMoveList, List<string> curMoves, List<string> solutions)
    {
        // test for halting conditions:
        // 1) count == 0: we're done with this solution
        if (count == 0)
        {
            solutions.Add(curMoveList);
            return;
        }
        // less than three boxes: invalid solution:
        else if (count < 3)
        {
            curMoves.Remove(curMoveList);
            return;
        }
        // keep moving..:
        foreach (string cm in curMoves)
            foreach (string k in moves.Keys)
            {
                int bc = count - moves[k];
                fullMove( bc, curMoveList + k,  curMoves, solutions );
            }
    }
