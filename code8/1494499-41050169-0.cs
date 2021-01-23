    //push a ball onto the tree
    public void PushB(Ball b)
    {
        if(leaf)
        {
            BallList.Add(b);
    
            if (BallList.Count > thresh_hold)
            {
                //test if branching will produce a viable area
                if ((max_w / 2) - min_w >= 10)
                {
                    Branch();
                }
            }
        }
        else
        {
            LeafPush(b); //push the ball to a leaf node
        }
        return;
    }
