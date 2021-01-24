    private void DpTimerTick_GetEnemyAmmo(object sender, EventArgs e)
    {
        lstBEnemies.SelectedItem = EnemyList[0];
    }
----------
    <Label Content="{Binding SelectedItem.Ammo, ElementName=lstBEnemies}" />
