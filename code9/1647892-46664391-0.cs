    public class CtContextMenuItem
    {
        public Visibility IsVisible { get; set; }
    }
----------
    <ContextMenu ItemsSource="{Binding TheSourceCollection}">
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="Visibility" Value="{Binding IsVisible}" />
            </Style>
        </ContextMenu.ItemContainerStyle>
    </ContextMenu>
