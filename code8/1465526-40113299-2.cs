                void IDispatchMessageInspector.BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
                {
                    try
                    {
                        ValidateMessage(ref reply);                
                    }
                    catch (FaultException fault)
                    {
                        // handle the fault and create the reply
                        // choose one of the CreateMessage overloads    
                        reply = Message.CreateMessage(reply.Version, "SOME MESSAGE");                    
                    }
                }
