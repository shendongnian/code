    class ParentClass
    {
        public virtual bool Method()
        {
            return false;
        }
    }
    
    class ChildClass : ParentClass
    {
        public override bool Method()
        {
            var toContinue = base.Method();
            if (!toContinue)
            {
                return false;
            }
    
            //Continue..
    
            return true;
        }
    }
