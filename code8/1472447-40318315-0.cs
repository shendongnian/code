    _hubConnection.Reconnecting += Function() 
    If _hubConnection.State = ConnectionState.Reconnecting Then
    	CanSend = False
    	Status = "Connection reconnecting..."
    End If
    
    End Function
    
    _hubConnection.Reconnected += Function() 
    If _hubConnection.State = ConnectionState.Connected Then
    	Status = String.Format("Connected to {0} via {1}", _hubUrl, _hubConnection.Transport.Name)
    	CanSend = True
    End If
    
    End Function
    
    _hubConnection.Closed += Function() 
    If _hubConnection.State = ConnectionState.Disconnected Then
    	CanSend = False
    	Status = "Connection lost, reconnecting in a bit..."
    	Await Task.Delay(_reconnectDelay)
    	Await Connect()
    End If
    
    End Function
    
    _hubConnection.[Error] += Function(ex) 
    LogMessages.Add(ex.ToString())
    
    End Function 
    
