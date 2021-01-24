    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Pivot Grid.Row="1" Grid.Column="1">
            <Pivot.HeaderTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding}" FontSize="18" />
                </DataTemplate>
            </Pivot.HeaderTemplate>
            <PivotItem x:Name="Tab1" Header="Tab 1">
                <ListView x:Name="matchesList" ScrollViewer.IsHorizontalScrollChainingEnabled="True">
                    <ListView.ItemTemplate>
                        <DataTemplate x:DataType="local:Data">
                            <Grid>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{x:Bind Match}"/>
                                </StackPanel>
                            </Grid>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                </ListView>
            </PivotItem>
            <PivotItem x:Name="Tab2" Header="Tab 2">
            </PivotItem>
        </Pivot>
    </Grid>
