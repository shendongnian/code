    var coreItemIds = coreData.Select(coreItem => coreItem.Id)
        .Distinct();
    IEnumerable<TableData> newestAuditData = auditedData
        // take only auditedData that is still in coreData
        .Where(auditedItem => coreItemIds.Contains(auditedItem.CoreId)
        // group the remaining items by same CoreId
        .GroupdBy(
            auditedItem => auditedItem.CoreId,     // key of the group: coreId
            autitedItem => auditedItem.TableData); // elements of the group
        // from every group (= all audited items belonging to the same core item)
        // take the element with the newest date
        // = order by descending AuditDate and take FirstOrDefault
        // because a group is created you are certain there is an element in the group
        .Select(group => group
            .OrderbyDescending(groupElement => groupElement.AuditDate)
            .FirstOrDefault());
