    for (int i = 0; i < _maxSessions; i++)
     {
         sessionDetail sd = new sessionDetail((GuiSession)sapConnection.Sessions.Item(i), false, i);
         sessionList.Add(sd);
     }
    class sessionDetail
    {
        public GuiSession sapSession { get; }
        public bool isUsed { get; set; }
        public int sessionId { get; set; }
        public sessionDetail(GuiSession SapSession, bool IsUsed, int SessionId)
        {
            sapSession = SapSession;
            isUsed = IsUsed;
	        sessionId = SessionId;
        }
    }
