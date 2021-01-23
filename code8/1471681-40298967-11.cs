    private void FillOutNodesWithRefs (Node startingNode)
    {
        int startingId = 0;
        RecursiveCallWithRefs(startingNode, ref startingId);
    }
    private void FillOutNodesWithReturns (Node startingNode)
    {
        RecursiveCallWithReturns(startingNode, 0);
    }
