    static void Main(string[] args)
            {
                try
                {
                    CallOtherLibrary();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
    
    
            private static void HandleException(Exception ex)
            {
                if (ex is ExceptionA)
                {
                    ProcessErrorA();
                }
                else if (ex is ExceptionB)
                {
                    ProcessErrorB();
                }
            }
