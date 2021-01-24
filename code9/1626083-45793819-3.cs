    [ImportMany(typeof(Lazy<IConfirmShellClosing>))]
    private IEnumerable<Lazy<IConfirmShellClosing>> _confirmShellClosingClients;
    
        private void ExecuteWindowClosing(CancelEventArgs args)
            {
                if (_confirmShellClosingClients != null)
                {
                    foreach (var client in _confirmShellClosingClients)
                    {
                        if (!client.Value.CanShellClose)
                        {
                            // Show your Dialog here and handle the answer
                        }
                    }
                }
            }
