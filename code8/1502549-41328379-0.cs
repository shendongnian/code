        public void OnLoad()
        {
            FiddlerApplication.OnLoadSAZ += HandleLoadSaz;
        }
        private void HandleLoadSaz(object sender, FiddlerApplication.ReadSAZEventArgs e)
        {
            FiddlerApplication.UI.lvSessions.BeginUpdate();
            foreach (var session in e.arrSessions)
            {
                OnPeekAtResponseHeaders(session); //Run whatever function you use in IAutoTamper
                session.RefreshUI();
            }
            FiddlerApplication.UI.lvSessions.EndUpdate();
        }
