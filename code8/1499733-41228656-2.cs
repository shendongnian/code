    <ItemsControl ItemsSource="{Binding VehicleCollection}">
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Visibility"
                        Value="{Binding IsVisible,
                                Converter={StaticResource BooleanToVisibilityConverter}}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                ...
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
