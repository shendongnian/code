    var statuses = this.StatusRepository.GetActiveStatuses().ToLookup(x => x.StatusId);
    var types = this.TypeRepository.GetActiveTypes().ToLookup(x => x.TypeId);
    var emptyStatus = Status.Empty();
    var emptyType = Type.Empty();
    var contracts = this.ContractApi.GetCurrentContracts()
        .Select(x => new ContractItem {
            Id = x.Id,
            Name = x.Name,
            Status = statuses[x.StatusId].DefaultIfEmpty(emptyStatus),
            Type = types[x.TypeId].DefaultIfEmpty(emptyType)
        });
