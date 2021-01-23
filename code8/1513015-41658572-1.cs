    void tcpConnect_ClientConnected(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                //then it is called from other thread, so use invoke method to make UI thread update its field
                this.Invoke(new Action(() => UpdateLabelText()));
            }
            else
            {
                //then it is called from UI and can be updated directly
                UpdateLabelText();
            }
        }
        private void UpdateLabelText()
        {
            labelControl1.Text = "Connected";
        }
