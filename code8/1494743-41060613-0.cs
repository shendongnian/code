    //remove the if before the for loop
    for (int j = 0; j < 12; j++)
    {
        if (blocks.Count >= 52)
        {
            break; //exit the for loop
        }
        blockXpos += (61);
        blocks.Add(new Blocks(Content.Load<Texture2D>("Blocks\\DurasteelBlock"), blockXpos, blockYpos));
        if (j == 11)
        {
            for (int i = 0; i < 1; i++)
            {
                blockXpos = 3;
                blocks.Add(new Blocks(Content.Load<Texture2D>("Blocks\\DurasteelBlock"), blockXpos, blockYpos));
                blockYpos += (51);
                if (i == 1)
                {
                    j = 0;
                }         
            }
        }
    }
