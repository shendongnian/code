    IEnumerable<VirtualFabric> virtualFabrics = this.VirtualFabricList
        .Select(t => t.Value>);
    IEnumerable<Dictionary<string, SANSwitch>> dictionaries = virtualFabrics
        .Select(fabric => fabric.MemberSwitches);
    IEnumerable<SanSwitch> sanSwitches = dictionaries
        .SelectMany(dictionary => dictionary.Values);
