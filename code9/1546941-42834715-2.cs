        // please, notice "using static"
        using static MyLibrary.MyStorage;
        namespace myNamespace
        {
            public class MyClass 
            {
                public void MyMethod() 
                {
                    myString = "abc"; // as if it has been declared in the namespace
                    string test = myString;  
                    ...
                }
            } 
        }
