    foreach(Mission m in Database.Instance.Missions)
    {
        string missionName = m.MissionName;
        DraggableNodeAddMissionList.Add(new ContextMenuVM()
        {
            DisplayName = missionName ,
            ContextMenuCommand = new RelayCommand(
                () =>
                {
                    MessageBox.Show("You clicked!" + missionName);
                })
        });
    }
