    public static int CountWhoHasTwoSameSons(BinNode<int> Head)
    {
        if (Head != null)
        {
            if (IsLeaf(Head))
                return 1;
    
            if (Head.HasLeft() && Head.HasRight())
            {
                if (Head.GetRight()**.GetValue**() == Head.GetLeft().**GetValue()**))
                    return 1 + CountWhoHasTwoSameSons(Head.GetLeft()) + CountWhoHasTwoSameSons(Head.GetRight());
                
            }
            return CountWhoHasTwoSameSons(Head.GetLeft()) + CountWhoHasTwoSameSons(Head.GetRight());
        }
        return 0;
    }
