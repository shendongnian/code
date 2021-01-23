    public class TCT_Fix : Control, IApplication
    {
        private readonly string username = [removed]
        private readonly string password = [removed]
        public string InitiatorID;                           
        SessionID sessionID;                                 
        public bool running;                                 
        SessionSettings settings;
        IMessageStoreFactory storeFactory;
        ILogFactory logFactory;
        SocketInitiator initiator;
        public event EventHandler AddToLB;
        public event EventHandler AddToAdmin;
        public void StopIt()
        {
            if (sessionID == null) return;
            try
            {
                Session.LookupSession(sessionID).Disconnect("Stopping");
                settings.Remove(sessionID);
                settings = null;
                initiator.Dispose();
                settings = new SessionSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fix", "initiator.cfg"));
                storeFactory = new FileStoreFactory(settings);
                logFactory = new FileLogFactory(settings);
                initiator = new SocketInitiator(
                    this,
                    storeFactory,
                    settings,
                    logFactory);
            }
            catch { }   
        }
        public void FromApp(QuickFix.Message msg, SessionID sessionID)
        {
            var sMsg = "FROM APP: " + msg.ToString();
            AddToLB(sMsg, null);
            if (msg.Header.GetField(35) == "TC") //Cash
            {
                DateTime dtTdate;
                float fPrice;
                int Qty;
                int OrdType;
                bool BPisBuyer;
                DateTime.TryParse(msg.GetField(CustomConstants.TDATE),out dtTdate);
                string BPSide = msg.GetField(CustomConstants.BP_SIDE);                
                float.TryParse(msg.GetField(CustomConstants.F_PRICE), out fPrice);
                int.TryParse(msg.GetField(CustomConstants.QTY), out Qty);
                string TCTReference = msg.GetField(CustomConstants.TCT_REF);
                string BPAcct = msg.GetField(CustomConstants.BP_COMPANY);
                int.TryParse(msg.GetField(CustomConstants.ORDER_TYPE), out OrdType);
                string ExecBkr = msg.GetField(CustomConstants.EXEC_BKR);
                string CounterParty = msg.GetField(CustomConstants.COUNTER_PARTY);
                BPisBuyer = msg.GetField(CustomConstants.IS_BUYER) == "Y";
                string BPTrader = msg.GetField(CustomConstants.BP_TRADER);
                string CounterTrader = msg.GetField(CustomConstants.COUNTER_TRADER);
                string Grade = msg.GetField(CustomConstants.GRADE);
                string Location = msg.GetField(CustomConstants.LOCATION);
                string CycDt = msg.GetField(CustomConstants.CYCLE_DATE);
                string DelMo = msg.GetField(CustomConstants.DELIVER_MONTH);
                string Terms = msg.GetField(CustomConstants.TERMS);
                string Payment = msg.GetField(CustomConstants.PAYMENT);
                string Origin = msg.GetField(CustomConstants.ORIGIN);
                string NumOfCyc = msg.GetField(CustomConstants.NUM_OF_CYCLES);
                string Via = msg.GetField(CustomConstants.VIA);
                string MoveMo = msg.GetField(CustomConstants.MOVE_MONTH);
                string Comment = msg.GetField(CustomConstants.COMMENT);
            }
            else if (msg.Header.GetField(35) == "TE") //EFP
            {
                DateTime dtTdate;
                float fPrice;
                int Qty;
                int OrdType;
                bool BPisBuyer;
                bool IsWater;
                DateTime.TryParse(msg.GetField(CustomConstants.TDATE), out dtTdate);
                string BPSide = msg.GetField(CustomConstants.BP_SIDE);
                float.TryParse(msg.GetField(CustomConstants.F_PRICE), out fPrice);
                int.TryParse(msg.GetField(CustomConstants.QTY), out Qty);
                string TCTReference = msg.GetField(CustomConstants.TCT_REF);
                string BPAcct = msg.GetField(CustomConstants.BP_COMPANY);
                int.TryParse(msg.GetField(CustomConstants.ORDER_TYPE), out OrdType);
                string ExecBkr = msg.GetField(CustomConstants.EXEC_BKR);
                string CounterParty = msg.GetField(CustomConstants.COUNTER_PARTY);
                BPisBuyer = msg.GetField(CustomConstants.IS_BUYER) == "Y";
                string BPTrader = msg.GetField(CustomConstants.BP_TRADER);
                string CounterTrader = msg.GetField(CustomConstants.COUNTER_TRADER);
                string Grade = msg.GetField(CustomConstants.GRADE);
                string Location = msg.GetField(CustomConstants.LOCATION);
                string CycDt = msg.GetField(CustomConstants.CYCLE_DATE);
                string DelMo = msg.GetField(CustomConstants.DELIVER_MONTH);
                string Terms = msg.GetField(CustomConstants.TERMS);
                string Payment = msg.GetField(CustomConstants.PAYMENT);
                string Origin = msg.GetField(CustomConstants.ORIGIN);
                string NumOfCyc = msg.GetField(CustomConstants.NUM_OF_CYCLES);
                string Via = msg.GetField(CustomConstants.VIA);
                string MoveMo = msg.GetField(CustomConstants.MOVE_MONTH);
                string Comment = msg.GetField(CustomConstants.COMMENT);
                IsWater = msg.GetField(CustomConstants.ISWATER) == "Y";
                string BPFloorBkr = msg.GetField(CustomConstants.BP_FLOOR_BKR);
                string CounterFloorBkr = msg.GetField(CustomConstants.COUNTER_FLOOR_BKR);
                string Diff = msg.GetField(CustomConstants.DIFFERENCE);
                string MercMo = msg.GetField(CustomConstants.MERC_MO);
                string MercPr = msg.GetField(CustomConstants.MERC_PRICE);
            }
            else if (msg.Header.GetField(35) == "TI") //Index
            {
                DateTime dtTdate;
                float fPrice;
                int Qty;
                int OrdType;
                bool BPisBuyer;
                bool IsWater;
                DateTime.TryParse(msg.GetField(CustomConstants.TDATE), out dtTdate);
                string BPSide = msg.GetField(CustomConstants.BP_SIDE);
                float.TryParse(msg.GetField(CustomConstants.F_PRICE), out fPrice);
                int.TryParse(msg.GetField(CustomConstants.QTY), out Qty);
                string TCTReference = msg.GetField(CustomConstants.TCT_REF);
                string BPAcct = msg.GetField(CustomConstants.BP_COMPANY);
                int.TryParse(msg.GetField(CustomConstants.ORDER_TYPE), out OrdType);
                string ExecBkr = msg.GetField(CustomConstants.EXEC_BKR);
                string CounterParty = msg.GetField(CustomConstants.COUNTER_PARTY);
                BPisBuyer = msg.GetField(CustomConstants.IS_BUYER) == "Y";
                string BPTrader = msg.GetField(CustomConstants.BP_TRADER);
                string CounterTrader = msg.GetField(CustomConstants.COUNTER_TRADER);
                string Grade = msg.GetField(CustomConstants.GRADE);
                string Location = msg.GetField(CustomConstants.LOCATION);
                string CycDt = msg.GetField(CustomConstants.CYCLE_DATE);
                string DelMo = msg.GetField(CustomConstants.DELIVER_MONTH);
                string Terms = msg.GetField(CustomConstants.TERMS);
                string Payment = msg.GetField(CustomConstants.PAYMENT);
                string Origin = msg.GetField(CustomConstants.ORIGIN);
                string NumOfCyc = msg.GetField(CustomConstants.NUM_OF_CYCLES);
                string Via = msg.GetField(CustomConstants.VIA);
                string MoveMo = msg.GetField(CustomConstants.MOVE_MONTH);
                string Comment = msg.GetField(CustomConstants.COMMENT);
                IsWater = msg.GetField(CustomConstants.ISWATER) == "Y";
                string BPFloorBkr = msg.GetField(CustomConstants.BP_FLOOR_BKR);
                string CounterFloorBkr = msg.GetField(CustomConstants.COUNTER_FLOOR_BKR);
                string Diff = msg.GetField(CustomConstants.DIFFERENCE);
                string MercMo = msg.GetField(CustomConstants.MERC_MO);
                string MercPr = msg.GetField(CustomConstants.MERC_PRICE);
                
            }
        }
        public void OnCreate(SessionID sessionID)
        {
            AddToAdmin("SESSION CREATED: " + sessionID.ToString(), null);
        }
        public void OnLogout(SessionID sessionID)
        {
            AddToAdmin("LOGOUT: " + this.sessionID.ToString(), null);       
        }
        public void OnLogon(SessionID sessionID)
        {
            this.sessionID = sessionID;
            AddToAdmin("LOG ON: " + this.sessionID.ToString(),null);
        }
        public void FromAdmin(QuickFix.Message msg, SessionID sessionID)
        {
            AddToAdmin("FROM ADMIN: " + msg.ToString(), null);
        }
        public void ToAdmin(QuickFix.Message msg, SessionID sessionID)
        {
            if (msg.Header.GetField(35).ToString() == "A")
            {
                msg.SetField(new QuickFix.Fields.Username(username));
                msg.SetField(new QuickFix.Fields.Password(password));
            }
            AddToAdmin("TO ADMIN: " + msg.ToString(), null);
        }
        public void ToApp(QuickFix.Message msg, SessionID sessionID)
        {
            AddToLB("TO APP: " + msg.ToString(), null);       
        }        
        public void GetTestMessage(string msgType)
        {
            if (sessionID == null) return;
            QuickFix.FIX50.TestMessage msg = new QuickFix.FIX50.TestMessage();
            msg.TestType = msgType;
            msg.Header.SetField(new QuickFix.Fields.MsgType("TEST"));
            msg.SetField(new QuickFix.Fields.StringField(CustomConstants.TEST_TYPE, msgType));
            Session.SendToTarget(msg, sessionID);
        }
        public TCT_Fix()
        {
            settings = new SessionSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fix", "initiator.cfg"));
            storeFactory = new FileStoreFactory(settings);
            logFactory = new FileLogFactory(settings);
            initiator = new SocketInitiator(
                this,
                storeFactory,
                settings,
                logFactory);
        }
        public TCT_Fix(ref string initID)
        {
            InitiatorID = initID;
            settings = new SessionSettings(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fix", "initiator.cfg"));
            storeFactory = new FileStoreFactory(settings);
            logFactory = new FileLogFactory(settings);
            initiator = new SocketInitiator(
                this,
                storeFactory,
                settings,
                logFactory);
        }
        public void RunIt()
        {
            if (running) return;
            if(initiator.IsStopped)
            {
                try
                {   
                    initiator.Start(); //This can throw an error due to current set up.  I would recommend making the connection,
                                       //pulling data, and then closing the connection (polling) to ensure the initiator clears the
                                       //log files
                                       //reference http://lists.quickfixn.com/pipermail/quickfixn-quickfixn.com/2013q1/000747.html
                                       //2013 issue, still unresolved...  Restart app
                }
                catch(Exception ex)
                {
                    if (MessageBox.Show("Error restarting initiator.  Program will close due to file access.  This is a Quickfix bug, not an issue with this program.  Please restart." + Environment.NewLine + Environment.NewLine +
                        "Reference: http://lists.quickfixn.com/pipermail/quickfixn-quickfixn.com/2013q1/000747.html for more information.  Click ok to copy link to clipboard.  Click \"X\" to ignore.") == DialogResult.OK)
                    {
                        Clipboard.SetText("http://lists.quickfixn.com/pipermail/quickfixn-quickfixn.com/2013q1/000747.html");
                    }
                    throw new Exception(ex.ToString());
                }
            }          
            running = true;           
        }
    }
