    TapiManager tapiManager = new TapiManager("TapiCallMonitor.net");
    if (tapiManager.Initialize() == false)
            {
                MessageBox.Show("No Tapi devices found.");
                this.Close();
                return;
            }
    foreach (TapiLine line in tapiManager.Lines)
            {
                try 
                {
                    line.NewCall += OnNewCall;
                    line.CallStateChanged += OnCallStateChanged;
                    line.CallInfoChanged += OnCallInfoChanged;
                    line.Monitor();
                }
                catch (TapiException ex)
                {
                    LogError(ex.Message);
                }
            }
