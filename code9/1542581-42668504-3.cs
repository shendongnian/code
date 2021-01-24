    var result = callsData.Select(x => x);
    
    if (IncludeIncomingCalls) {
        result = result.Where(x => x.IncomingCall);
    }
    else {
        result = result.Where(x => !x.IncomingCall);
    }
    
    if (IncludeOutgoingCalls) {
        result = result.Where(x => x.OutgoingCall);
    }
    else {
        result = result.Where(x => !x.OutgoingCall);
    }
    
    if (IncludeExternalCalls) {
        result = result.Where(x => x.ExternalCall);
    }
    else {
        result = result.Where(x => !x.ExternalCall);
    }
    
    return result;
