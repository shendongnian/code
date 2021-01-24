    public void SendPrivateMessage(string toUserId, string message)
            {
    
                string fromUserId = Context.ConnectionId;
    
                var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId) ;
                var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);
    
                if (toUser != null && fromUser!=null)
                {
                    // send to 
                    Clients.Client(toUserId).sendMessage(fromUserId, fromUser.UserName, message); 
    
                    // send to caller user as well to update caller chat
                    Clients.Caller.sendMessage(toUserId, fromUser.UserName, message); 
                }
    
            }
