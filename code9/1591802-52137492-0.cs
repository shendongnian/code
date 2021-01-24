    // find initial ordering
    foreach(int io in original)
    {
        int pos = -1;
        for (int i = 0; i < desired.Length; i++)
        {
            if (desired[i] == io)
            {
                pos = i;
                break;
            }
        }
        original2.Add(pos);
    }
