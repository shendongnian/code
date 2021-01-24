    private static void AcceptCallback(IAsyncResult result)
    {
        var listener = (Socket)result.AsyncState;
        var handler = listener.EndAccept(result);
        var state = new StateObject();
        state.WorkSocket = handler;
        LbConnections.Add(new SimClient { State = state });
        handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, SocketFlags.None, ReceiveCallback, state);
        ServerSocket.BeginAccept(AcceptCallback, ServerSocket);  // <<---
    }
