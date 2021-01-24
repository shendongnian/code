    <TabControl>
        <TabControl.Resources>
            <Style TargetType="TabItem" BasedOn="{StaticResource {x:Type TabItem}}">
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Image Source="{Binding HeaderImage}" Height="20" Margin="5, 0"/>
                                <TextBlock Text="{Binding HeaderText}"/>
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TabControl.Resources>
        <TabItem DataContext="{Binding ViewModelStart}" Header="{Binding}">
        </TabItem>
        <TabItem DataContext="{Binding ViewModelStartupManager}" Header="{Binding}">
        </TabItem>
    </TabControl>
