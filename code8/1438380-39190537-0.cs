    int test1(bool someCondition)
    {
      int x = 0;
      if( someCondition )
      {
        x = 1;
      }
      return x;
    }
    
    int test2(bool someCondition)
    {
      int x;
      if( someCondition )
      {
        x = 1;
      }
      else
      {
        x = 0;
      }
      return x;
    }
    int test3(bool someCondition)
    {
      return someCondition ? 1 : 0;
    }
    
    int test4(bool someCondition)
    {
      return int(someCondition);
    }
