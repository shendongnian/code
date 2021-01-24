    foreach(Mission m in Database.Instance.Missions)
    {
        var item = new ContextMenuVM()
        {
            DisplayName = m.MissionName,
        };
        item.ContextMenuCommand = new RelayCommand(
            () =>
            {
                MessageBox.Show("You clicked!" + item.DisplayName);
            })
        DraggableNodeAddMissionList.Add(item);
    }
