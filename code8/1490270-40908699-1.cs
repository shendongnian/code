    class UIException : Exception
    {
        public UIException(Exception baseException) :
            base(GetErrorMessage(baseException), baseException)
        {
        }
    
        private static GetErrorMessage(Exception baseException)
        {
            if (baseException is IndexOutOfRangeException)
            {
                return "Index was outside the bounds of the array.";
            }
            else if (exception is InvalidOperationException)
            {
                //Return exception message
            }
            //... more else if in the chain
            else
            {
                return baseException.Message;
            }
        }
    }
