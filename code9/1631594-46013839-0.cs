    class MyLogicBase
    {
        …
    
        public virtual void UpgradeInstance(MyLogicBase newInstance)
        { 
            m_Database = from.m_Database;
        }
        
        protected List<string> m_Database = new List<string>();
    }
    
    class MyExtendedLogic : MyLogicBase
    {
        public override void UpgradeInstance(MyLogicBase newInstance)
        {
            base.UpgradeInstance(newInstance);
            …
        }
        …    
    }
