        private void OnNewIncomingCall(ITCallInfo ici)
        {
            ITBasicCallControl bcc = (ITBasicCallControl)ici;
            if (bcc != null)
            {
                string caller = ici.get_CallInfoString(CALLINFO_STRING.CIS_CALLERIDNUMBER);
                DialogResult dlg = MessageBox.Show(string.Format("New incoming call from {0}\r\nDo you wish to answer the call now?", caller), "New incoming call", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                    bcc.Answer();
            }
        }
