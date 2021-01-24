    <ContextMenu ItemsSource="{Binding Items}" HorizontalContentAlignment="Stretch">
        <ContextMenu.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}" />
            </DataTemplate>
        </ContextMenu.ItemTemplate>
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="InputGestureText" Value="{Binding GestureText}"/>
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
