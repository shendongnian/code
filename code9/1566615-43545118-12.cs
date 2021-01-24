    public static class ExecutionEngine
    {
        public static T Execute<T>(this IEnumerable<IResult> method)
        {
            List<Message> messages = new List<Message>();
            try
            {
                foreach (var item in method)
                {
                    // yield return null is ignored here:
                    if (item != null)
                    {
                        // Handle validation results, messages, etc
                        Message msg = item as Message;
                        if (msg != null)
                        {
                            msg.Handle(messages);
                        }
                        Result<T> returnValue = item as Result<T>;
                        if (returnValue != null)
                        {
                            return returnValue.Value;
                        }
                    }
                }
                throw new Exception("Method finished without a return value.");
            }
            catch (ValidationException)
            {
                // TODO: handle messages?
                throw;
            }
            catch (Exception ex)
            {
                // TODO: handle messages?
                var error = new Error(ex);
                error.Handle(messages);
                throw; // unreachable because Error throws. This is to make sure it all compiles
            }
        }
    }
