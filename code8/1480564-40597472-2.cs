    public void GetTestMessage(string msgType)
        {
            if (sessionID == null) return;
            QuickFix.FIX50.TestMessage msg = new QuickFix.FIX50.TestMessage();
            msg.TestType = msgType;
            msg.Header.SetField(new QuickFix.Fields.MsgType("TEST"));
            msg.SetField(new QuickFix.Fields.StringField(CustomConstants.TEST_TYPE, msgType));
            Session.SendToTarget(msg, sessionID);
        }
