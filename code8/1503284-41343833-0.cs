    <ListView x:Name="lv">
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <StackPanel.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="..." />
                        </ContextMenu>
                    </StackPanel.ContextMenu>
                    <StackPanel.ToolTip>
                        <ToolTip>
                            <TextBlock>Tooltip...</TextBlock>
                        </ToolTip>
                    </StackPanel.ToolTip>
                    <Button Content="Button"/>
                    <TextBlock Text="..." />
                    <ComboBox>
                        <ComboBoxItem>1</ComboBoxItem>
                        <ComboBoxItem>2</ComboBoxItem>
                        <ComboBoxItem>3</ComboBoxItem>
                    </ComboBox>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
