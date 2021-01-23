            var ex = context.Exception;
            while (ex != null)
            {
                if (ex is MyException)
                {
                    // Do work
                    break;
                }
                ex = ex.InnerException;
            }
