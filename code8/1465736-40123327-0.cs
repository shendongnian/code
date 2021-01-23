    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.Resources>
            <local:BoolToBrushConverter x:Key="cvt" />
        </Grid.Resources>
        <ListView x:Name="listview" ItemsSource="{x:Bind Collection, Mode=OneWay}"
                  SelectionChanged="listview_SelectionChanged">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="40" />
                        </Grid.ColumnDefinitions>
                        <StackPanel Background="{Binding IsSelected, Converter={StaticResource cvt}}">
                            <TextBlock Text="{Binding Name}" />
                        </StackPanel>
                        <TextBlock Grid.Column="1" Text="{Binding Age}" />
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
