    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <!-- ItemsControl with Canvas as ItemsPanel for graphical representation -->
        <ItemsControl ItemsSource="{Binding Shapes}">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <Canvas/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Path Data="{Binding Geometry}"
                          Fill="{Binding Fill}"
                          Stroke="{Binding Stroke}"
                          StrokeThickness="{Binding StrokeThickness}"/>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
        <!-- ListView for shape data -->
        <ListView Grid.Column="1" ItemsSource="{Binding Shapes}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Type"
                                    DisplayMemberBinding="{Binding Type}"/>
                    <GridViewColumn Header="X"
                                    DisplayMemberBinding="{Binding Geometry.Bounds.X}"/>
                    <GridViewColumn Header="Y"
                                    DisplayMemberBinding="{Binding Geometry.Bounds.Y}"/>
                    <GridViewColumn Header="Width" 
                                    DisplayMemberBinding="{Binding Geometry.Bounds.Width}"/>
                    <GridViewColumn Header="Height" DisplayMemberBinding="{Binding Geometry.Bounds.Height}"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
