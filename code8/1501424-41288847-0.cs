    <Setter Property="ToolTip">
        <Setter.Value>
            <ToolTip>
                <ItemsControl ItemsSource="{Binding Path=PlacementTarget.(Validation.Errors), RelativeSource={RelativeSource AncestorType=ToolTip}}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding ErrorContent}" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </ToolTip>
        </Setter.Value>
    </Setter>
