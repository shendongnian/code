    AddHandler consumer.Received, Sub(consumer as IBasicConsumer, ea as BasicDeliverEventArgs)
                                     Dim body = ea.Body
                                     '...  
                                     channel.BasicAck(ea.DeliveryTag, false, false)
                                  End Sub
