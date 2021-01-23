                void IDispatchMessageInspector.BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
                {
                    try
                    {
                        ValidateMessage(ref reply);                
                    }
                    catch (FaultException fault)
                    {
                        // if a validation error occurred, the message is replaced
                        // with the validation fault.
                        reply = Message.CreateMessage(reply.Version, new FaultException("validation error in reply message").CreateMessageFault() , reply.Headers.Action);
                    }
                }
