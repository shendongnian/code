    <Style TargetType="{x:Type MenuItem}">
        <Setter Property="Command" Value="{Binding DataContext.AddColumnCommand, RelativeSource={RelativeSource AncestorType=UserControl}}"/>
        <EventSetter Event="PreviewMouseLeftButtonDown" Handler="OnMouseDown" />
    </Style>
-
    private void OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        MenuItem mi = sender as MenuItem;
        if (mi != null && mi.Command != null && mi.HasItems)
             mi.Command.Execute(mi.CommandParameter);
    }
