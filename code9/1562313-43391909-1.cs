    <TextBox Text="test">
        <TextBox.ContextMenu>
            <ContextMenu>
                <MenuItem Header="111"></MenuItem>
                <MenuItem Header="222"></MenuItem>
                <MenuItem Header="333" GotKeyboardFocus="MenuItem_GotKeyboardFocus">
                    <MenuItem Header="fff" />
                    <MenuItem Header="ggg" />
                </MenuItem>
                <MenuItem Header="444"></MenuItem>
            </ContextMenu>
        </TextBox.ContextMenu>
    </TextBox>
    	private void MenuItem_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    	{
    if ((sender as MenuItem) != null)
    			{
    				Dispatcher.BeginInvoke((Action)(() => { (sender as MenuItem).IsSubmenuOpen = true; }), null);
    			}
    	}
