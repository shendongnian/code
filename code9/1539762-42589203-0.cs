    <ListBox ItemsSource="{Binding Items}" MinHeight="100" TabIndex="0" x:Name="LB">
        <ListBox.ContextMenu>
            <ContextMenu>
                <MenuItem Header="Foo" Command="{Binding ContCommand}" 
                                  CommandParameter="{Binding RelativeSource={RelativeSource AncestorType={x:Type ContextMenu}},
                                    Path=PlacementTarget.SelectedItem}"/>
            </ContextMenu>
        </ListBox.ContextMenu>
    </ListBox>
