    int maxCount = 2;
    int attCount = 0;
    public int[] AttackTriggers; //Add the trigger ID's to the array via the editor.
    public float attackResetTime = 1.0f; //Will take one second to reset counter.
    if(Input.GetKeyDown(KeyCode.Q))
    {
      anim.SetTrigger(AttackTriggers[attCount]);
      attCount++;
      if(attCount > maxCount)
      {
         attCount = 0;
      }
    }
