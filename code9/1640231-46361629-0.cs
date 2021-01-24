    <Style x:Key="SelectedRowBackground" TargetType="{x:Type UserControl}">
        <Style.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <EventTrigger.Actions>
                    <BeginStoryboard>
                        <Storyboard>
                            <ColorAnimation
                                        Storyboard.TargetProperty="(UserControl.Background).(SolidColorBrush.Color)"
                                        To="Green" Duration="0:0:1" />
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger.Actions>
            </EventTrigger>
        </Style.Triggers>
    </Style>
----------
    private void UpdateSweepView()
    {
        if (!sweepingColumns)
            foreach (CardControl item in currentCardControls)
            {
                if (item.Row == selectedRow)
                    item.Style = (Style)FindResource("SelectedRowBackground");
                else
                    item.Style = (Style)FindResource("NormalRowBackground");
                grid.Children.Remove(item);
                item.Unloaded += Uc_Unloaded;
            }
        ...
    }
    private void Uc_Unloaded(object sender, RoutedEventArgs e)
    {
        grid.Children.Add(uc); //this will fire the Loading event and apply the animation
        uc.Unloaded -= Uc_Unloaded;
    }
