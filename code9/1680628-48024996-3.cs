    if(Input.GetKeyDown(KeyCode.Q))
    {
      StopCoroutine(ResetAttCount());
      anim.SetTrigger(AttackTriggers[attCount]);
      attCount++;
      if(attCount > maxCount)
      {
         attCount = 0;
      }
    }
