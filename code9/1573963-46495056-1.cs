        private void DoSomeWork(string scrptTask, List<sessionDetail> _sessionList)
        {
            sessionDetail _sessionToUse;
            foreach (sessionDetail s in _sessionList)
            {
                if (!s.isUsed)
                {
                    _sessionToUse = s;
                    s.isUsed = true;
                    //// Do your stuff here
                    s.isUsed = false;
                    break;
                }
            }
        }
