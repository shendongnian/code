    MyNamespace
    {
        class MyClassName
        {
            //class wide variables go here
            int myVariable; //class wide variable
            public MyClassName() //this is the constructor
            {
                myVariable = 1; // assigns value to the class wide variable
            }
            
            private MyMethod()
            {
                int myTempVariable = 4; // method bound variable, only useable inside this method
                myVariable = 3 + myTempVariable; //myVariable is accessible to whole class, so can be manipulated
            }
        }
    }
