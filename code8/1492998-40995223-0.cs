    private async void AddLocalChangesFromPendingOperations()
    {
        var pendingOperations = await this.operationsStorage.GetOperationsAsync();
        (await Task.WhenAll(pendingOperations
            .SelectMany(pendingOperation =>
                               pendingOperation.Settings, (pendingOperation, setting) =>
                               new { pendingOperation, setting })
            .Where(a => a.setting.Key == "selection")
            .Select(a => Tuple.Create(a.pendingOperation.DefinitionId, Convert.ToInt32(a.setting.Value.ValueObject)))
            .Select(async pendingChange => Tuple.Create(await this.selectionsStorage.GetSelectionByIdAsync(pendingChange.Item2)), pendingChange))
            .SelectMany(tuple => this.SelectionsList.Where(a => a.Name == tuple.Item1.Name)
                                                    .Select(selectionsViewModel => Tuple.Create(selectionsViewModel, tuple.Item2))
            .Select(tuple => Tuple.Create(tuple.Item1, tuple.Item2.Item1 == "selection-add-animals"))
            .ToList()
            .ForEach(tuple => tuple.Item1.IsActive = tuple.Item2);
    }
