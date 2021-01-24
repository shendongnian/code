    public void ChangeReportConnection(string connnectionSring)
        {
            if (_PowerBIContext == null)
            {
                _PowerBIContext = new PowerBIContext(connnectionSring);
            }
        }
