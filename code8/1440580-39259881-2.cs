    private async Task CheckConditionsAsync()
    {
        foreach (var obj in myObjects)
        {
            if (obj.ConditionMet)
            {
                await HandleConditionAsync(obj);
            }
        }
        DoOtherWork();
    }
