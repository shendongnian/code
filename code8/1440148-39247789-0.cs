    <Grid.ContextMenu>
    <ContextMenu Margin="10,10,0,13" Name="ContextMenu" HorizontalAlignment="Left" VerticalAlignment="Top" IsOpen="False">
        <ContextMenu.ItemsSource>
            <Binding RelativeSource="{RelativeSource TemplatedParent}" Path="ChildCommands"/>
        </ContextMenu.ItemsSource>
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="{x:Type MenuItem}">
                <Setter Property="MenuItem.Header" Value="{Binding Command.Text}"/>
                <Setter Property="MenuItem.IsEnabled" Value="False"/>
            </Style>
        </ContextMenu.ItemContainerStyle>
        <ContextMenu.ItemsPanel>
            <ItemsPanelTemplate>
                <VirtualizingStackPanel Orientation="Vertical"/>
            </ItemsPanelTemplate>
        </ContextMenu.ItemsPanel>
    </ContextMenu>
    </Grid.ContextMenu>
