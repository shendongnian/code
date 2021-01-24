    public static class SafeActionInvokator
    {
        /// <summary>
        /// Executes a method, and if any exception is thrown, will log the error and swallow the exception.
        /// </summary>
        /// <param name="methodToExecute"></param>
        public static MethodInvokationResult HandleSafely(Action methodToExecute)
        {
            try
            {
                methodToExecute.Invoke();
                return new MethodInvokationResult()
                {
                    Exception = null,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex}");
                return new MethodInvokationResult()
                {
                    Exception = ex,
                    Success = false
                };
            }
        }
    }
