    public string GetModelName(int? modelId)
    {
        if (!modelId.HasValue)
            return "n/a";
    
        return _inventoryService.GetModel(modelId.Value).Name;
    }
