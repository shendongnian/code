    <ItemsControl ItemsSource="{Binding CheckBoxList}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="149.6*" />
                        <ColumnDefinition Width="149.6*" />
                        <ColumnDefinition Width="149.6*" />
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="28*" />
                        <RowDefinition Height="28*" />
                        <RowDefinition Height="28*" />
                    </Grid.RowDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Grid.Row" Value="{Binding GridRow}" />
                <Setter Property="Grid.Column" Value="{Binding GridColumn}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <CheckBox Margin="14,6,63,6"
                              VerticalAlignment="Center"
                              Content="{Binding Content}"
                              IsChecked="{Binding IsChecked}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
