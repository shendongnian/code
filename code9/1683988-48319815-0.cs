    public partial class Form1 : Form
        {
            TAPIClass _tapi;
            ITAddress _line;
            int _cn;
            
         public Form1()
            {
                InitializeComponent();
    
                _tapi = new TAPIClass();
                _tapi.Initialize();
                foreach (ITAddress ad in (ITCollection)_tapi.Addresses)
                {
                    if (ad.AddressName.StartsWith("Cisco"))
                        cbLines.Items.Add(ad.AddressName);
                }
    
                if (cbLines.Items.Count == 0) return;
    
                _tapi.EventFilter = (int)(TAPI_EVENT.TE_CALLNOTIFICATION |
                                        TAPI_EVENT.TE_CALLINFOCHANGE |
                                        TAPI_EVENT.TE_DIGITEVENT |
                                        TAPI_EVENT.TE_PHONEEVENT |
                                        TAPI_EVENT.TE_CALLSTATE |
                                        TAPI_EVENT.TE_GENERATEEVENT |
                                        TAPI_EVENT.TE_GATHERDIGITS |
                                        TAPI_EVENT.TE_REQUEST);
                _tapi.ITTAPIEventNotification_Event_Event += tapi_ITTAPIEventNotification_Event_Event;
                cbLines.SelectedIndex = 0;
    
                button1_Click(null, null);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (_line != null)
                {
                    _line = null;
                    if (_cn != 0) _tapi.UnregisterNotifications(_cn);
                }
                
                foreach (ITAddress ad in (ITCollection)_tapi.Addresses)
                {
                    if (ad.AddressName == cbLines.Text)
                    {
                        _line = ad;
                        break;
                    }
                }
                if (_line != null)
                {
                    _cn = _tapi.RegisterCallNotifications(_line, true, true, TapiConstants.TAPIMEDIATYPE_AUDIO, 2);
                }
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                if (_cn != 0) _tapi.UnregisterNotifications(_cn);
            }
    
            delegate void AddLogDelegate(string text);
            private void AddLog(string text)
            {
                if (InvokeRequired)
                {
                    Invoke(new AddLogDelegate(AddLog), text);
                }
                listBox1.Items.Insert(0, text);
            }
    
            private void tapi_ITTAPIEventNotification_Event_Event(TAPI_EVENT tapiEvent, object pEvent)
            {
                try
                {
                    switch (tapiEvent)
                    {
                        case TAPI_EVENT.TE_CALLSTATE:
                            var cn2 = pEvent as ITCallStateEvent;
                            switch (cn2?.Call.CallState)
                            {
                                case CALL_STATE.CS_OFFERING:
                                    var c = cn2.Call.CallInfoString[CALLINFO_STRING.CIS_CALLERIDNUMBER];
                                    AddLog("Call Offering: " + c + " -> " + cn2.Call.Address.DialableAddress);
                                    break;
                                case CALL_STATE.CS_CONNECTED:
                                    AddLog("Call Started at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.FFF"));
                                    break;
                                case CALL_STATE.CS_IDLE:
                                    break;
                                case CALL_STATE.CS_INPROGRESS:
                                    AddLog("Outgoing Call: from " + cn2.Call.Address.DialableAddress + " to " + teNumber.Text + " at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.FFF"));
                                    break;
                                case CALL_STATE.CS_DISCONNECTED:
                                    AddLog("Call Finished at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.FFF"));
                                    break;
                                case CALL_STATE.CS_HOLD:
                                    break;
                                case CALL_STATE.CS_QUEUED:
                                    break;
                                case null:
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (_line == null) return; 
                 var bc = _line.CreateCall(teNumber.Text, TapiConstants.LINEADDRESSTYPE_PHONENUMBER, TapiConstants.TAPIMEDIATYPE_AUDIO);
                bc.Connect(false);
            }
        }
