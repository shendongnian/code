    <ListBox SelectionChanged="ListBoxItem_SelectionChanged" 
                     HorizontalAlignment="Stretch" VerticalAlignment="Stretch" Background="#FFFFFF"
                     Grid.Row="2" Grid.Column="1" Grid.ColumnSpan="3" BorderThickness="0"
                     ItemsSource="{Binding ItemsSource, RelativeSource={RelativeSource AncestorType=UserControl}}"
                     SelectedItem="{Binding SelectedItem, RelativeSource={RelativeSource AncestorType=UserControl}}">
        <ListBox.ItemContainerStyle>
            <Style TargetType="{x:Type ListBoxItem}" BasedOn="{StaticResource {x:Type ListBoxItem}}">
                <EventSetter Event="MouseDoubleClick" Handler="ListBoxItem_MouseDoubleClick"/>
                <EventSetter Event="KeyDown" Handler="ListBoxItem_KeyDown"/>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
----------
    public class ctlDirFilesListBox : UserControl
    {
        //...
        public static readonly DependencyProperty ItemsSourceProperty =
             DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ctlDirFilesListBox));
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(ctlDirFilesListBox));
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
