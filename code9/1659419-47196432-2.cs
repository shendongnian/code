    System.Threading.Timer _timeoutTimer;
    private readonly object _timeoutTimerLock = new object();
    private void ResetTimeoutTimer() {
        // if you are sure you will never access this from multiple threads at the same time - remove lock
        lock (_timeoutTimerLock) {
            // initialize or reset the timer to fire once, after 2 seconds
            if (_timeoutTimer == null)
                _timeoutTimer = new System.Threading.Timer(ReconnectAfterTimeout, null, TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
            else
                _timeoutTimer.Change(TimeSpan.FromSeconds(2), Timeout.InfiniteTimeSpan);
        }
    }
    private void StopTimeoutTimer() {
        // if you are sure you will never access this from multiple threads at the same time - remove lock
        lock (_timeoutTimerLock) {
            if (_timeoutTimer != null)
                _timeoutTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        }
    }
    private void ReconnectAfterTimeout(object state) {
        // reconnect here
    }
    public void SetWebSocketSharpEvents() {
        ws.Log.Level = LogLevel.Trace;
        ws.OnOpen += (sender, e) => {
            // start timer here so that if you don't get first message after 2 seconds - reconnect
            ResetTimeoutTimer();
            IsConnected = true;
            OnWSOpen("Connection Status :: Connected *********");
        };
        ws.EmitOnPing = true;
        ws.OnMessage += (sender, e) => {
            // and here
            ResetTimeoutTimer();
            if (e.IsPing) {
                OnWSMessage("ping received");
            }
            else {
                OnWSMessage(e.Data);
            }
        };
        ws.OnError += (sender, e) => {
            // stop it here
            StopTimeoutTimer();
            IsConnected = false;
            OnWSError(e.Message); //An exception has occurred during an OnMessage event. An error has occurred in closing the connection.
      
      if (ws.IsAlive)
                    ws.Close();
            };
            ws.OnClose += (sender, e) => {
                // and here
                StopTimeoutTimer();
                IsConnected = false;
                OnWSClose("Close");
            };
            ws.ConnectAsync();
        }
