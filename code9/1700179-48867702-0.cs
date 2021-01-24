    <ItemsControl x:Name="iccc">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition />
                        <RowDefinition />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock>cell 2:2...</TextBlock>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Grid.Row" Value="1" />
                <Setter Property="Grid.Column" Value="1" />
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
