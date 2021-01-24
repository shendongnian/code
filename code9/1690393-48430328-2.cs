    {
      int i = 0;
      DoTheLoopTest:
      if (i < 10)
        goto DoTheLoopBody;
      else
        goto DoneTheLoop;
      DoTheLoopBody:
      {
        if ((i % 2) == 0)
          goto DoTheLoopIncrement;
        Console.Write (i + " ");
        DoTheLoopIncrement: 
        ++i;
        goto DoTheLoopTest;
      }
    }
    DoneTheLoop:
    ...
