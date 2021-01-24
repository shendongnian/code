    int maxCount = 2;
    int attCount = 0;
    public int[] AttackTriggers;
    if(Input.GetKeyDown(KeyCode.Q))
    {
      anim.SetTrigger(AttackTriggers[attCount]);
      attCount++;
      if(attCount > maxCount)
      {
         attCount = 0;
      }
    }
