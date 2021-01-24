     //If your fingerprint(or your card) passes the verification,this event will be triggered,only for color device
            void axCZKEM1_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
            {
                string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;
    
                gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);
    
                throw new NotImplementedException();
            }
    
            //If your fingerprint(or your card) passes the verification,this event will be triggered,only for black%white device
            private void axCZKEM1_OnAttTransaction(int EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second)
            {
                string time = Year + "-" + Month + "-" + Day + " " + Hour + ":" + Minute + ":" + Second;
                gRealEventListBox.Items.Add("Verify OK.UserID=" + EnrollNumber.ToString() + " isInvalid=" + IsInValid.ToString() + " state=" + AttState.ToString() + " verifystyle=" + VerifyMethod.ToString() + " time=" + time);
    
                throw new NotImplementedException();
            }
    
            //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
            //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
            void axCZKEM1_OnVerify(int UserID)
            {
                if (UserID != -1)
                {
                    gRealEventListBox.Items.Add("User fingerprint verified... UserID=" + UserID.ToString());
                }
                else
                {
                    gRealEventListBox.Items.Add("Failed to verify... ");
                }
    
                throw new NotImplementedException();
            }
