    public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
    {
    
        if (suspensionState.ContainsKey(nameof(Value)))
        {
            Value = suspensionState[nameof(Value)]?.ToString();
        }
        else if (parameter != null)
        {
            if (parameter is string)
            {
                Value = parameter?.ToString();
            }
            else
            {
                var coll = parameter as IEnumerable<string>;
            }
        }
        await Task.CompletedTask;
    }
