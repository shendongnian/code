    <TabControl
        >
        <TabControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*" />
                        <ColumnDefinition Width="Auto" />
                    </Grid.ColumnDefinitions>
                    <Label
                        Content="{Binding Content.TabHeader, RelativeSource={RelativeSource AncestorType=TabItem}}"
                        Grid.Column="0"
                        />
                    <Button
                        VerticalAlignment="Center"
                        Grid.Column="1"
                        >
                        <Path
                            Data="M 0, 0 L 12, 12 M 12,0 L 0,12"
                            Stroke="Red"
                            StrokeThickness="2"
                            Width="12"
                            Height="12"
                            />
                    </Button>
                </Grid>
            </DataTemplate>
        </TabControl.ItemTemplate>
        <local:UserControl1 TabHeader="First Item" />
        <local:UserControl1 TabHeader="Second Item" />
    </TabControl>
