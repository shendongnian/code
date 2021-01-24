    foreach (Scene s in Database.Instance.Scenes)
    {
        int id = s.SceneID;
        SceneAddMenu.Add(new ContextMenuVM()
        {
            DisplayName = s.SceneName,
            ContextMenuCommand = new RelayCommand(
            () =>
            {
                MessageBox.Show("Clicked " + id.ToString());
            })
        });
    }
