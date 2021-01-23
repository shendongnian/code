    void M1()
    {
      try { N(); } catch (MyException) { if (F()) C(); }
    }
    void M2()
    {
      try { N(); } catch (MyException) when F() { C(); }
    }
    void N()
    {
      try { MakeAMess(); DoSomethingDangerous(); } 
      finally { CleanItUp(); }
    }
