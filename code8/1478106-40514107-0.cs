    // example
    
    private int m_passedInValue;
    
    public MyForm2()
    {
      InitializeConstrols();
    }
    
    public MyForm2(int thePassedValue)
     : this()
    {
      m_passedInValue = thePassedValue;
    }
    
    // the form1 call
    void SomeOpenFormMethod()
    {
      var form2 = new MyForm2(20);
      form2.Show();
    }
