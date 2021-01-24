    public UserControlBase() : base()
    {     
      if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
      {
       m_engine = Engine.Instance();
      }
      else 
         m_engine = new Engine();  
    }
