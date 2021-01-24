    <Button x:Name="btn_action" Content="Action" FontSize="11" Margin="3,0,3,0" 
                    Style="{DynamicResource btn-primary}" Width="65" Click="btn_action_Click"
                    Tag="{Binding RelativeSource={RelativeSource AncestorType=UserControl}}">
        <Button.ContextMenu>
            <ContextMenu x:Name="bank_history_dropdown_menu" Style="{DynamicResource MaterialDesignContextMenu}" >
                <MenuItem  IsEnabled="{Binding PlacementTarget.Tag.DataContext.CanDelete, RelativeSource={RelativeSource AncestorType=ContextMenu}}"
                           Name="menuItem_clear" Header="Clear" Height="36" Style="{StaticResource MaterialDesignMenuItem}" Click="menuItem_clear_Click" />
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
