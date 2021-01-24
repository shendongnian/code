        public class callnotification : TAPI3Lib.ITTAPIEventNotification
        {
            public InboundCall OnNewIncomingCall;
            public void Event(TAPI_EVENT TapiEvent, object pEvent)
            {
                switch (TapiEvent)
                {
                    case TAPI_EVENT.TE_CALLNOTIFICATION:
                        this.OnCallNotification((ITCallNotificationEvent)pEvent);
                        break;
                }
            }
            private void OnCallNotification(ITCallNotificationEvent callNotification)
            {
                ITCallInfo ici = callNotification.Call;
                if (ici != null && ici.CallState == CALL_STATE.CS_OFFERING)
                    this.OnNewIncomingCall(ici);
            }
        }
