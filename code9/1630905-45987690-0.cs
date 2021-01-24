       public void Test()
        {
            Type type = typeof(FunctionList);
            MethodInfo method = type.GetMethod("MyMethod");
            FunctionList c = new FunctionList();
            // if you dont know the type of parameter passed then you have to write a parser to determine the type of the parameter right before executing the method. 
            method.Invoke(c, new object[] { "lorem ipsum" , 10});
        }
    }
    public class FunctionList
    {
        public void MyMethod(string x, int y)
        {
            MessageBox.Show(x + " : " + y);
        }
    }
