    public static int CountWhoHasTwoSameSons(BinNode<int> Head)
     {
            if (Head == null)
                return 0;
            if (IsLeaf(Head))
                return 1;
            if ((Head.HasLeft() && Head.HasRight()) &&
               (Head.GetRight() == Head.GetLeft()))  // It happens with this if statement!
                  return 1 + CountWhoHasTwoSameSons(Head.GetLeft()) + 
                  CountWhoHasTwoSameSons(Head.GetRight());
    
     }
