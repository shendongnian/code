                    catch (AggregateException ae)
                    {
                        endMessage = string.Format("Defined Query failed. Error: {0}", ae.Message);
                        // Set specific error message when TaskCanceledException is contained in AggregateException
                        var fe = ae.InnerException as FaultException<ExceptionDetail>;
                        if (fe != null) if (Type.GetType(fe.Detail.Type) == typeof(TaskCanceledException)) endMessage = "Defined Query was cancelled";
                        
                        logLevel = LogLevel.Error;
                        messageType = MessageType.Error;
                    }
