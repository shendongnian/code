    interface DancesWithWolves
    {
        void DanceWithWolves();
    }
    
    class MyClass2 : DancesWithWolves
    {
        public void DanceWithWolves() { /* ... */ }
    }
    
    class MyClass1 : DancesWithWolves
    {
        private readonly DancesWithWolves m_myClass2;
    
        public MyClass1(DancesWithWolves myClass2)
        {
            m_myClass2 = myClass2;
        }
    
        public void DanceWithWolves()
        {
            m_myClass2.DanceWithWolves();
        }
    }
    
    class MyClass3
    {
         public void MyClass3Method(DancesWithWolves myClass1)
         {
            myClass1.DanceWithWolves();
         }
    }
