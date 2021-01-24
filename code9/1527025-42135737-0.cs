    <TabControl ItemsSource="{Binding Path=Workspaces}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="local:AttachedProperties.RegisterCommandBindings" Value="{Binding RelativeSource={RelativeSource Self}, Path=CommandBindings}" />
                <Setter Property="HeaderTemplate" Value="{StaticResource ClosableTabItemTemplate}"/>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
