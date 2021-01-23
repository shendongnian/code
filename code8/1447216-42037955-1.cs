    protected override  bool  ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (msg.Msg == 256)
        {
            //if the user pressed control + s
            if (keyData == (Keys.Control | Keys.S))
            {
            }
            //if the user pressed control + o 
            else if (keyData == (Keys.Control | Keys.O))
            {
                
            }
            //if the user pressed control + n 
            else if (keyData == (Keys.Control | Keys.N))
            {
                
            }
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }
