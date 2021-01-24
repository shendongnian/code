    <ListBox SelectionMode="Extended">
        <ListBox.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="OnMouseLeftButtonDown"/>
            </Style>
        </ListBox.ItemContainerStyle>
        <ListBoxItem>1</ListBoxItem>
        <ListBoxItem>2</ListBoxItem>
        <ListBoxItem>3</ListBoxItem>
    </ListBox>
----------
    private void OnMouseLeftButtonDown(object sender, MouseEventArgs e)
    {
        ListBoxItem lbi = sender as ListBoxItem;
        if (lbi != null)
        {
            if (lbi.IsSelected)
            {
                lbi.IsSelected = false;
                e.Handled = true;
            }
        }
    }
