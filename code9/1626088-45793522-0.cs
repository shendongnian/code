    //CalculatorInterface.dll
    namespace Calculator.Interface
    {
        interface ICalculator
        {
            int DoCalculus(List<object> list);
        }
    }
    //CalculatorImplementation_1.dll
    //  Add a reference to CalculatorInterface.dll
    namespace Calculator.Implementation
    {
        using Calculator.Interface;
        class CalculatorImplementation_1 : ICalculator
        {
            public int DoCalculus(List<object> list)
            {
                int result = 0;
                foreach (Object obj in list)
                {
                    if (obj is int)
                    {
                        result += (int)obj;
                    }
                }
                return result;
            }
        }
    }
    //Calculator.dll
    //  Add a reference to CalculatorInterface.dll
    //  Add a reference to CalculatorImplementation_1.dll (or dynamically load it)
    namespace Calculator
    {
        using Calculator.Interface;
        using Calculator.Implementation;
        class MyCalculator
        {
            void CalculateSomething()
            {
                List<Object> list = new List<Object>();
                list.Add(1);
                list.Add(2);
                list.Add("SomeString");
                ICalculator calculator = new CalculatorImplementation_1();
                int result = calculator.DoCalculus(list);
                Console.Write(result);
            }
        }
    }
