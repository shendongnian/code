    Imports Microsoft.AspNet.SignalR
    Imports Microsoft.AspNet.SignalR.Hubs
    Imports Microsoft.AspNet.SignalR.Messaging
    Imports System.Threading.Tasks
    Imports Microsoft.ServiceBus
    Imports Microsoft.ServiceBus.Messaging
    
    <HubName("djwHub")>
    Public Class djwHub
        Inherits Hub
    
        Private connectString As String = "Endpoint=sb://mynamespace.servicebus.windows.net/;SharedAccessKeyName=myKeyName;SharedAccessKey=myKey"
        Private queueName As String = "myQueueName"
        Private m_count As Integer
    
        Public Sub beginReadingMessageQue()
            Dim rf = MessagingFactory.CreateFromConnectionString(connectString)
    
            Dim taskTimer = Task.Factory.StartNew(Async Function()
                                                      Dim receiver = Await rf.CreateMessageReceiverAsync(queueName, ReceiveMode.PeekLock)
    
                                                      While True
                                                          Dim timeNow As String = DateTime.Now.ToString()
                                                          Clients.All.sendServerTime(timeNow)
    
                                                          Try
                                                              Dim message = Await receiver.ReceiveAsync(TimeSpan.FromSeconds(5))
    
                                                              If message IsNot Nothing Then
                                                                  Dim messageBody = message.GetBody(Of [String])()
    
                                                                  Clients.All.sendNewMessage(messageBody)
    
                                                                  Await message.CompleteAsync
                                                              Else
                                                                  'no more messages in the queue
                                                                  Exit Try
                                                              End If
                                                          Catch e As MessagingException
                                                              If Not e.IsTransient Then
                                                                  'Console.WriteLine(e.Message)
                                                                  'Throw
                                                              End If
                                                          End Try
    
                                                          'Delaying by 1/2 second.
                                                          Await Task.Delay(500)
                                                      End While
    
                                                  End Function, TaskCreationOptions.LongRunning)
        End Sub
    End Class
