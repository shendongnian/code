    public int sta_RegRealTime(ListBox lblOutputInfo)
            {
                if (GetConnectState() == false)
                {
                    lblOutputInfo.Items.Add("*Please connect first!");
                    return -1024;
                }
    
                int ret = 0;
    
                if (axCZKEM1.RegEvent(GetMachineNumber(), 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {
                    //common interface
                    this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);
                    this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);
                    this.axCZKEM1.OnFingerFeature += new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(axCZKEM1_OnFingerFeature);
                    this.axCZKEM1.OnDeleteTemplate += new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(axCZKEM1_OnDeleteTemplate);
                    this.axCZKEM1.OnNewUser += new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(axCZKEM1_OnNewUser);
                    this.axCZKEM1.OnHIDNum += new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(axCZKEM1_OnHIDNum);
                    this.axCZKEM1.OnAlarm += new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(axCZKEM1_OnAlarm);
                    this.axCZKEM1.OnDoor += new zkemkeeper._IZKEMEvents_OnDoorEventHandler(axCZKEM1_OnDoor);
    
                    //only for color device
                    this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                    this.axCZKEM1.OnEnrollFingerEx += new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(axCZKEM1_OnEnrollFingerEx);
    
                    //only for black&white device
                    this.axCZKEM1.OnAttTransaction -= new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);
                    this.axCZKEM1.OnWriteCard += new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(axCZKEM1_OnWriteCard);
                    this.axCZKEM1.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(axCZKEM1_OnEmptyCard);
                    this.axCZKEM1.OnKeyPress += new zkemkeeper._IZKEMEvents_OnKeyPressEventHandler(axCZKEM1_OnKeyPress);
                    this.axCZKEM1.OnEnrollFinger += new zkemkeeper._IZKEMEvents_OnEnrollFingerEventHandler(axCZKEM1_OnEnrollFinger);
    
    
                    ret = 1;
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    ret = idwErrorCode;
    
                    if (idwErrorCode != 0)
                    {
                        lblOutputInfo.Items.Add("*RegEvent failed,ErrorCode: " + idwErrorCode.ToString());
                    }
                    else
                    {
                        lblOutputInfo.Items.Add("*No data from terminal returns!");
                    }
                }
                return ret;
            }
   
