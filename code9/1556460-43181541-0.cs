    private void Expander_Loaded(object sender, RoutedEventArgs e)
    {
        Expander expander = sender as Expander;
        System.Windows.Controls.Primitives.ToggleButton HeaderSite = GetChildOfType<System.Windows.Controls.Primitives.ToggleButton>(expander);
        if (HeaderSite != null)
        {
            ContentPresenter cp = GetChildOfType<ContentPresenter>(HeaderSite);
            if (cp != null)
                cp.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
    }
    private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null) return null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            var result = (child as T) ?? GetChildOfType<T>(child);
            if (result != null) return result;
        }
        return null;
    }
----------
    <Expander IsExpanded="True" Loaded="Expander_Loaded">
        <Expander.Header>
            <DockPanel HorizontalAlignment="Stretch">
                <Button Style="{StaticResource ButtonStyle}" Content="Show Only" DockPanel.Dock="Right" Padding="15,0,15,0" Click="Button_Click"></Button>
                <TextBlock Text="{Binding Path=Name}" FontSize="18"></TextBlock>
            </DockPanel>
        </Expander.Header>
        <Expander.Style>
            <Style TargetType="{x:Type Expander}">
                <Setter Property="Background" Value="#f0f0f5"></Setter>
                <Setter Property="TextElement.FontFamily" Value="Arial Nova"/>
            </Style>
        </Expander.Style>
        <Expander.Content>
            <ItemsPresenter />
        </Expander.Content>
    </Expander>
