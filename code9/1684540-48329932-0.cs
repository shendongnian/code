    D3D11.InfoQueue infoQueue = _d3dDevice.QueryInterface<D3D11.InfoQueue>();
    infoQueue.SetBreakOnSeverity(D3D11.MessageSeverity.Corruption, true);
    infoQueue.SetBreakOnSeverity(D3D11.MessageSeverity.Error, true);
    infoQueue.SetBreakOnSeverity(D3D11.MessageSeverity.Message, true);
    infoQueue.SetBreakOnSeverity(D3D11.MessageSeverity.Warning, true);
