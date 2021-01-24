    var newValue = new {
        operationLogDataId = yieldMaster.OperationalLogDataModelResponse.Id,
        // etc etc...
    };                           .
    lock(listSpacialRecords) {
        listSpacialRecords.Add(newValue);
    }
