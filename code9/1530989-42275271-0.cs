    public override Task OnConnected()
    {
        Boolean isFoundAnydevice = false;
        if(receivedClientId.Length>0)   //With Param
        {
            int noOfSelectedDevice = _context.TargatedDevice.Where(x => x.PhoneId == receivedClientId).Count();
            if (noOfSelectedDevice > 0)
                isFoundAnydevice = true;
        }
        else   //With no Param
        {
            String deviceId = _context.Device.Where(d => d.ConnectionId == this.Context.ConnectionId).Select(d => d.ClientId).SingleOrDefault();
        int noOfSelectedDevice = _context.TargatedDevice.Where(x => x.PhoneId == deviceId).Count();
            if (noOfSelectedDevice > 0)
                isFoundAnydevice = true;
        }
        if (isFoundAnydevice)
        {
            _logger.LogWarning(
                            receivedClientId + " added to Test group"
                            );
            Groups.Add(this.Context.ConnectionId, testGroupName);
        }   
        return base.OnConnected();
    }
