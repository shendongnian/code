    <ItemsControl x:Name="PropertyDisplay" ItemsSource="{Binding Properties}" Grid.IsSharedSizeScope="True">
        <ItemsControl.Resources>
            <local:PropertyInfoValueConverter x:Key="PropertyInfoValueConverter"/>
        </ItemsControl.Resources>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding Name}" Margin="4,2"/>
                    <TextBlock Grid.Column="1" Margin="4,2"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
