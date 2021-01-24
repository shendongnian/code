    public void HandleKeyStroke(KeyboardState ks, KeyboardState oldks)
    {
        if (ks.IsKeyDown(GameplayButtons.ACTIONBAR_0) && oldks.IsKeyUp(GameplayButtons.ACTIONBAR_0))
            UIManager.actionToBeTriggered("actionbar_0");
        if (ks.IsKeyDown(GameplayButtons.ACTIONBAR_1) && oldks.IsKeyUp(GameplayButtons.ACTIONBAR_1))
            UIManager.actionToBeTriggered("actionbar_1");
        if (ks.IsKeyDown(GameplayButtons.ACTIONBAR_2) && oldks.IsKeyUp(GameplayButtons.ACTIONBAR_2))
            UIManager.actionToBeTriggered("actionbar_2");
        if (ks.IsKeyDown(GameplayButtons.ACTIONBAR_3) && oldks.IsKeyUp(GameplayButtons.ACTIONBAR_3))
            UIManager.actionToBeTriggered("actionbar_3");
        if (ks.IsKeyDown(GameplayButtons.CHARACTER) && oldks.IsKeyUp(GameplayButtons.CHARACTER))
            UIManager.ToggleWindowById("button_Character");
    }
