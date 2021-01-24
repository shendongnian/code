            try
            {
                ec.Next(1, out ici, ref arg);
                if (ici != null && ici.CallState == CALL_STATE.CS_OFFERING)
                {
                    ITBasicCallControl2 bc = (TAPI3Lib.ITBasicCallControl2)ici;
                    if (bc != null)
                    {
                        bc.Answer();
                    }
                }
            }
            catch (Exception exp)
            {
                COMException comEx = exp as COMException;
                if (comEx != null)
                    MessageBox.Show(comEx.ErrorCode.ToString());
                else
                    MessageBox.Show(exp.Message);
            }
