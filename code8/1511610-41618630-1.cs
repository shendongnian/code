    <ItemsControl ItemsSource="{Binding GridButtonList}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid Columns="{Binding GridColumns}" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Content="{Binding Text}" Background="{Binding Background}" Command="{Binding OnClick}" CommandParameter="{Binding}">
                    <Button.InputBindings>
                        <MouseBinding Gesture="RightClick" Command="{Binding OnRightClick}" CommandParameter="{Binding}" />
                    </Button.InputBindings>
                </Button>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
