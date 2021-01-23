    delegate void SetTextCallback(string text);
    private void SetDebugText(string RxString)
        {
            if (this.btnDebug.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetDebugText);
                this.Invoke(d, new object[] { RxString });
            }
            else
            {
                this.btnDebug.Text = RxString;
            }
        }
