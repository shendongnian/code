    class DynamicVisitor
    {
        public void Visit(BaseClass b)
        {
            Visit((dynamic)b);
        }
    
        public void Visit(Derived1 b) { /*do something*/ }
    
        public void Visit(Derived2 b) { /*do something*/ }
    }
