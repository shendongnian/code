    using System;
					
    public class Program
    {
	   public static void Main()
	   {
		  Example<string> test = new Example<string>(value1: "test");
          test.Print();//Prints test1
	   }
	
    class Example<T>
    {
        private object Value;
        public Example(T value1)
        {
           this.Value = value1 + "1";
        }
        public Example(string value2)
        {
            this.Value = value2 + "2";
        }
        public void Print()
        {
              Console.WriteLine(Value as string);
           }
        }	
    }
