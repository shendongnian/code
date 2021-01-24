            ExceptionDispatchInfo exceptionInfo = null;
            try
            {
                foo();
            }
            catch(Exception ex)
            {
                exceptionInfo = ExceptionDispatchInfo.Capture(ex);
            }
            finally
            {
                try
                {
                    bar();
                }
                catch(Exception ex)
                {
                    exceptionInfo = exceptionInfo ?? ExceptionDispatchInfo.Capture(ex);
                }
            }
            exceptionInfo?.Throw();
