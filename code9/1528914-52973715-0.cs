    public class MyEqualException : Xunit.Sdk.EqualException
    {
        public MyEqualException(object expected, object actual, string userMessage)
            : base(expected, actual)
        {
            UserMessage = userMessage;
        }
        public override string Message => UserMessage + "\n" + base.Message;
    }
    public static class AssertX
    {
        /// <summary>
        /// Verifies that two objects are equal, using a default comparer.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared</typeparam>
        /// <param name="expected">The expected value</param>
        /// <param name="actual">The value to be compared against</param>
        /// <param name="userMessage">Message to show in the error</param>
        /// <exception cref="MyEqualException">Thrown when the objects are not equal</exception>
        public static void Equal<T>(T expected, T actual, string userMessage)
        {
            if (!expected.Equals(actual))
            {
                throw new MyEqualException(expected, actual, userMessage);
            }
        }
    }
