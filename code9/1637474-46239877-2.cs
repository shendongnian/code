    ConditionalWeakTable<ContextMenuVM, Action> ActionHolder = new ConditionalWeakTable<ContextMenuVM, Action>();
    // keep action references alive, ActionHolder needs to have some
    // appropriate scope so it doesn't disappear as long as
    // ContextMenuVM is alive
    ...
    
        foreach(Mission m in Database.Instance.Missions)
        {
            var item = new ContextMenuVM()
            {
                DisplayName = m.MissionName,
            };
            Action a = () =>
                {
                    MessageBox.Show("You clicked!" + item.DisplayName);
                };
            item.ContextMenuCommand = new RelayCommand(a);
            DraggableNodeAddMissionList.Add(item);
            ActionHolder.Add(item, a); // keep a strong action reference for the lifetime of item
        }
