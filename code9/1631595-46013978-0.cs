    class MyLogicBase {
        …
        public virtual void UpgradeInstance(MyLogicBase newInstance)
        {
             //to override
        }
        protected CopyDatabase(MyLogicBase newInstance) {
             m_Database = newInstance.m_Database;
        }
        protected List<string> m_Database = new List<string>(); }
    class MyExtendedLogic : MyLogicBase
    {
        public override void UpgradeInstance(MyLogicBase newInstance)
        {
            base.CopyDatabase(newInstance);
            …
        }
        …    
    }
