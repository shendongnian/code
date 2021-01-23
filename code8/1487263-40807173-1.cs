    namespace projectB
    {
        Class RealA extends A
        {
            void toImplement() { does stuff }
        }
    
        Class RealAFactory implements AFactory
        {
            A create() { return new RealA() }
        }
    }
