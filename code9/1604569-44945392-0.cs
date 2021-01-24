    foreach (string t in singleCommand)
            {
                if (t.Trim().Length > 0)
                {
                    try
                    {
                        // do not use ExecutionTypes.ContinueOnError, it will not
                        // throw any exceptions
                        int result = Server
                            .ConnectionContext
                            .ExecuteNonQuery(scl, ExecutionTypes.Default); 
                    }
                    catch (ExecutionFailureException ex) 
                    {
                        // do anything
                        // do not throw error here
                    }
                    catch (Exception e)
                    {
                        // do anything
                        // do not throw error here
                    }
                }
            }
