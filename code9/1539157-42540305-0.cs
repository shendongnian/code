    virtual internal async Task<NetworkDeviceNodeStatus[]> GetRoutersOn3GBackupNodeStatusesAsync()
    {
      List<Branch3GInfo> branchActive3GInfos = new List<Branch3GInfo>();
      var nodeStatuses = new List<NetworkDeviceNodeStatus>();
      NetworkDeviceNodeStatus[] deviceStatuses = new NetworkDeviceNodeStatus[0];
      var result = GetNodesAsync();
      deviceStatuses = GetNetworkDeviceNodeStatuses(branchActive3GInfos.ToArray());
      return deviceStatuses;
    }
    private async Task<Branch3GInfo[]> GetNodesAsync()
    {
      var result = await GetNodesOn3GBackupAsyncInternal();
      branchActive3GInfos = result.Where(y => y.Status == Branch3GInfo.Branch3GStatus.Active).ToList();
      Trace.TraceInformation("Found " + x.Result.Count() + " CAS Nodes on 3G backup.");
      foreach (var branchActive3GInfo in branchActive3GInfos) {
        await branchActive3GInfo.RouterInfo.GetBasicInfoAsync();
        Trace.TraceInformation("Retrieved ModelBasicInfo for "
                + branchActive3GInfo.RouterInfo.GetBasicInfo());
      }
      return result;
    }
