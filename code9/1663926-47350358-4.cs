    bool hasStations = request.StationIds.Length > 0;
    bool hasDatapoints = request.DatapointIds.Length > 0;            
    int numFound = 0;
    List<ArchiveCacheValue> result;
    if (hasDatapoints && hasStations) {
        // special case - filter by both
        result = new List<ArchiveCacheValue>();
        // store station filter in hash set
        var stationsFilter = new HashSet<int>(request.StationIds);
        // first filter by datapoints, because you have more different datapoints than stations
        foreach (var datapointId in request.DatapointIds.OrderBy(c => c)) {                    
            foreach (var item in ArchiveCacheByDatapoint[datapointId]) {                        
                if (stationsFilter.Contains(item.StationId)) {
                    // both datapoint and station matches filter - found item
                    numFound++;
                    if (numFound >= request.Start && result.Count < request.Length) {
                        // add to result list if matches paging criteria
                        result.Add(item);
                    }
                }
            }
        }
    }
    else if (hasDatapoints) {                
        var query = Enumerable.Empty<ArchiveCacheValue>();                
        foreach (var datapoint in request.DatapointIds.OrderBy(c => c))
        {
            var list = ArchiveCacheByDatapoint[datapoint];
            numFound += list.Count;
            query = query.Concat(list);
        }
        // execute query just once
        result = query.Skip(request.Start).Take(request.Length).ToList();
    }
    else if (hasStations) {                
        var query = Enumerable.Empty<ArchiveCacheValue>();
        foreach (var station in request.StationIds.OrderBy(c => c))
        {
            var list = ArchiveCacheByStation[station];
            numFound += list.Count;
            query = query.Concat(list);
        }
        // execute query just once
        result = query.Skip(request.Start).Take(request.Length).ToList();
    }
    else {
        // no need to do Count()
        numFound = ArchiveCache.Count;
        // no need to Skip\Take here really, ArchiveCache is list\array
        // so you can use indexes which will be faster
        result = ArchiveCache.Skip(request.Start).Take(request.Length).ToList();
    }
    // Number of entries on the current page that will be shown
    int numShown = result.Count;
