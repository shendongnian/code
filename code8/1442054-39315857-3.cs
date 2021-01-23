    <DataGrid ItemsSource="{Binding Collection}" 
              funk:DataGridColumnsBehavior.FlipHeader="{Binding Flip}">
        <DataGrid.Resources>
            <Style x:Key="CheckBoxColumnHeaderStyle" 
                   TargetType="{x:Type DataGridColumnHeader}">
                <Setter Property="LayoutTransform">
                    <Setter.Value>
                        <RotateTransform Angle="270"/>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
