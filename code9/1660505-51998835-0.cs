     public void SendPrivateMessage(Messaging objMessaging)
        {
            var fromNurse = objConnectedUserList.FirstOrDefault(x => x.NurseId == objMessaging.FromNurseId);
            var toNurse = objConnectedUserList.FirstOrDefault(x => x.NurseId == objMessaging.ToNurseId);
            var chatObject = new { MessageThreadId = 0, Name = fromNurse.NurseName, Message = objMessaging.Message,  DTStmp = DateTime.Now, frmNurseId = fromNurse.NurseId };
            Result objResult = objMessagingDAL.InsertMessage(objMessaging);
            
            if (toNurse != null)
            {
                Clients.Client(toNurse.ConnectionId).ReceivePrivateMessage(chatObject);
            }
            Clients.Caller.ReceivePrivateMessage(chatObject);
        }
