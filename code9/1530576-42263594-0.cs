        <TabControl DataContext="{Binding}" ItemsSource="{Binding Models}"  >
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}" > 
                    </TextBlock>
                </DataTemplate>
            </TabControl.ItemTemplate>
            <TabControl.ContentTemplate>
                <DataTemplate>
                    <DockPanel>
                        <Button DockPanel.Dock="Top" Content="Click Me" Command="{Binding DataContext.PCommand, 
                                                                RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=TabControl}}"
                                CommandParameter="{Binding Desc}"/>
                        <TextBlock Text="{Binding Desc}" >
                        </TextBlock>
                    </DockPanel> 
                </DataTemplate>
            </TabControl.ContentTemplate>
        </TabControl>
