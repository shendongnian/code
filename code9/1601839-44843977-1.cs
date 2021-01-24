    <ItemsControl ItemsSource="{Binding Path=MyLabelList}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*" />
                        <RowDefinition Height="*" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Grid.Column" Value="{Binding columnNr}" />
                <Setter Property="Grid.Row" Value="{Binding rowNr}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding content}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
