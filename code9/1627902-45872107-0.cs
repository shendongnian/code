    <TabControl x:Name="Items" Grid.Row="1" Visibility="{Binding Visibility, Converter={StaticResource boolToVis}}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <!-- The Tab Names Binding with DisplayName-->
                    <TextBlock Text="{Binding DisplayName}" />
                    <Border x:Name="CanCloseTab">
                        <!-- The Tab Close Icon-->
                        <Button Content="x" x:Name="CloseTab" cal:Message.Attach="CloseTab" Style="{DynamicResource appTabCloseButton}" />
                    </Border>
                </StackPanel>
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
