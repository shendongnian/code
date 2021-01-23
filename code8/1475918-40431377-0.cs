    public static Action<GridActionCommandFactory<T>> GetDefaultGridCommands<T>(Action<GridActionCommandFactory<T>> customCommandsBeforeDefault = null, Action<GridActionCommandFactory<T>> customCommandsAfterDefault = null) where T : class
        {
            Action<GridActionCommandFactory<T>> defaultCommands = x =>
            {
                x.Custom("Edit").Text("<span class='k-icon k-edit'></span>").Click("editRecord");
                x.Custom("Delete").Text("<span class='k-icon k-i-delete'></span>").Click("deleteItem");
            };
            List<Action<GridActionCommandFactory<T>>> actions = new List<Action<GridActionCommandFactory<T>>>();
            if(customCommandsBeforeDefault != null)
                actions.Add(customCommandsBeforeDefault);
            actions.Add(defaultCommands);
            if(customCommandsAfterDefault != null)
                actions.Add(customCommandsAfterDefault);
            Action<GridActionCommandFactory<T>> combinedAction = (Action<GridActionCommandFactory<T>>) Delegate.Combine(actions.ToArray());
            return combinedAction;
        }
