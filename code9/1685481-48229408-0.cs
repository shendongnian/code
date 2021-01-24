    private void DecodeTHR(byte[] serialInput)
    {
        if(this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)(() => DecodeTHR(serialInput)));
            return; //This is to ensure that the method does not execute twice.
        }
        startVoltage.Value = serialInput[2];
        endVoltage.Value = serialInput[3];
        mode.SelectedIndex = serialInput[4];
        if (serialInput[5] == 255)
            assistLevelTH.SelectedIndex = 0;
        else
            assistLevelTH.SelectedIndex = serialInput[5] + 1;
        if (serialInput[6] == 255)
            speedLimitTH.SelectedIndex = 0;
        else
            speedLimitTH.SelectedIndex = serialInput[6] - 14;
        startCurrentTH.Value = serialInput[7];
        // RestartPort();
        if (next_op == rdSingle)
        {
            MessageBox.Show("Throttle Handle flash read successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        else
        {
            MessageBox.Show("Flash read successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            next_op = rdIgnore;
        }
    }
