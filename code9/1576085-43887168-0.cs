    <ItemsControl ItemsSource="{Binding SelectedCategory}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid helper:GridHelpers.RowCount="100"
                      helper:GridHelpers.ColumnCount="3"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Column}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Grid.Column" Value="{Binding Column}"/>
                <Setter Property="Grid.ColumnSpan" Value="{Binding ColumnSpan}"/>
                <Setter Property="Grid.Row" Value="{Binding Row}"/>
                <Setter Property="Grid.RowSpan" Value="{Binding RowSpan}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
