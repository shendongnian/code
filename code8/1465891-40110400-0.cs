    class Program
    {
        static void Main(string[] args)
        {
            List<Container> myValueStorage = new List<Container>();
            
            for (int i = 1; i < WhateverAmountOfOperations; i++)
            {
                myValueStorage.Add(YourMethod(yourParams));
            }
        }
        public static Container YourMethod(yourParams)
        {
            //Perform your calculations and store your results in the following variables
            double[] double_results; //An array of doubles
            double[][] double_array_results; //An array of double arrays
            
            //Create and return a class object containing the values
            return new Container(double_results, double_array_results);
        }
    }
    class Container
    {
        double[] _doubles { get; }
        double[][] _double_arrays { get; }
        public Container (double[] doubles, double[][] double_arrays)
        {
            _doubles = doubles;
            _double_arrays = double_arrays;
        }
    }
