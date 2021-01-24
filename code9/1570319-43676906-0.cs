    <ListView Grid.Row="1" Name="TicketListView">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListBoxItem">
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="TicketListView_PreviewMouseLeftButtonDown" />
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.View>
            <GridView>
                <GridViewColumn Header="Owned" DisplayMemberBinding="{Binding Owned}"/>
                <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}"/>
                <GridViewColumn Header="Price" DisplayMemberBinding="{Binding Price, ConverterCulture='en-US', StringFormat={}{0:C2}}"/>
                <GridViewColumn Header="Amount">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBox MinWidth="20" TextAlignment="Center" Margin="5" Text="{Binding Bought, Mode=TwoWay, UpdateSourceTrigger=LostFocus}" />
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
----------
    private void TicketListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ListViewItem lvi = sender as ListViewItem;
        TextBox textBox = GetChildOfType<TextBox>(lvi);
        if (textBox != null)
        {
            textBox.Dispatcher.BeginInvoke(new Action(() =>
            {
                bool b = textBox.Focus();
                Keyboard.Focus(textBox);
            }));
        }
    }
    private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null)
            return null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            var result = (child as T) ?? GetChildOfType<T>(child);
            if (result != null) return result;
        }
        return null;
    }
