      //method example
        public void ClassGet(MyClass MyClassName,string blabla)
        {
            object instance = Activator.Create(MyClassName);
        }
        
        // Call it like:
        
        Gold g = new Gold();
        g.ClassGet(MyClass, "blabla");
