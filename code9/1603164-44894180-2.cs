    public static class MyFakeBusinessEngine
    {
        /// <summary>
        /// Divides two numbers
        /// </summary>
        /// <param name="a">numerator</param>
        /// <param name="b">denominator</param>
        /// <returns>the result</returns>
        /// <exception cref="System.DivideByZeroException">When b is zero, divide by zero exception is thrown.</exception>
        public static int DivideTwoNumbers(int a, int b)
        {
            return a / b;
        }
    }
